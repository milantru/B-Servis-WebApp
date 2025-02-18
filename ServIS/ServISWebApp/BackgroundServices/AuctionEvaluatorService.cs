﻿using MimeKit;
using ServISData.Interfaces;
using ServISData.Models;
using ServISWebApp.Shared;
using ServISWebApp.Shared.Extensions;

namespace ServISWebApp.BackgroundServices
{
    /// <summary>
    /// Service for evaluating auction offers based on a timer interval.
    /// </summary>
    public class AuctionEvaluatorService : TimerService
	{
		private readonly IServISApi api;
		private readonly EmailManager emailManager;
		private readonly string baseUrl;
		private event Func<Task>? updateEvent;
		private bool isEvaluationInProgress = false;
		private ILogger<AuctionEvaluatorService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuctionEvaluatorService"/> class 
		/// with the specified dependencies and interval of the evaluation.
        /// </summary>
        /// <param name="api">The <see cref="IServISApi"/> implementation for API interactions.</param>
        /// <param name="emailManager">The <see cref="EmailManager"/> for sending emails.</param>
        /// <param name="baseUrl">The base URL of the application.</param>
        public AuctionEvaluatorService(
			IServISApi api,
			EmailManager emailManager,
			string baseUrl,
			ILogger<AuctionEvaluatorService> logger
		) : base(interval: TimeSpan.FromMinutes(1))
		{
			this.api = api;
			this.emailManager = emailManager;
			this.baseUrl = baseUrl;
			this.logger = logger;

			RegisterEventHandler();
		}

		public override void Dispose()
		{
			base.Dispose();

			emailManager.Dispose();
		}

		protected override Func<Task>? GetEventHandlers() => updateEvent;

		private async Task NotifyAdminAuctionEndedWithoutWinnerAsync(DateTime dateTimeNow, AuctionOffer ao)
		{
			var linkToAuctionOfferDetail = $"{baseUrl}/aukcna-ponuka/{ao.Id}";

			var header = new Header(
				field: "X-ServIS-url",
				value: linkToAuctionOfferDetail
			);

			var autogeneratedMessage = 
				await api.GetAutogeneratedMessageAsync(AutogeneratedMessage.For.AdminWhenAuctionEndsWithoutWinner);

			var auctionSummary = new AuctionSummary(ao);

			var subject = autogeneratedMessage.FormatSubject(auctionSummary);
			var message = autogeneratedMessage.FormatMessage(auctionSummary);

			var emailForAdmin = new Email
			{
				DateTime = dateTimeNow,
				FromName = emailManager.EmailName,
				FromAddress = emailManager.EmailAddress,
				ToName = emailManager.EmailName,
				ToAddress = emailManager.EmailAddress,
				Headers = new() { header },
				Subject = subject,
				Text = message
			};

			await emailManager.SendEmailAsync(emailForAdmin);
		}

		private async Task NotifyAdminAuctionEndedWithWinnerAsync(
			DateTime dateTimeNow,
			AuctionBid maxAuctionBid,
			User auctionWinner,
			string auctionWinnerFullname
		)
		{
			var linkToAuctionOfferDetail = $"{baseUrl}/aukcna-ponuka/{maxAuctionBid.AuctionOffer.Id}";

			var header = new Header(
				field: "X-ServIS-url",
				value: linkToAuctionOfferDetail
			);

			var autogeneratedMessage =
				await api.GetAutogeneratedMessageAsync(AutogeneratedMessage.For.AdminWhenAuctionEndsWithWinner);

			var auctionSummary = new AuctionSummary(maxAuctionBid.AuctionOffer, maxAuctionBid);

			var subject = autogeneratedMessage.FormatSubject(auctionSummary);
			var message = autogeneratedMessage.FormatMessage(auctionSummary);

			var emailForAdmin = new Email
			{
				FromName = emailManager.EmailName,
				FromAddress = emailManager.EmailAddress,
				ToName = emailManager.EmailName,
				ToAddress = emailManager.EmailAddress,
				ReplyToName = auctionWinnerFullname,
				ReplyToAddress = auctionWinner.Email,
				Subject = subject,
				Text = message,
				Headers = new() { header },
				DateTime = dateTimeNow
			};

			await emailManager.SendEmailAsync(emailForAdmin);
		}

		private async Task NotifyUserAsync(DateTime dateTimeNow, User user, string userFullname, string subject, string text)
		{
			var header = new Header(
				field: "X-ServIS-autogenerated",
				value: "true"
			);

			var emailForWinner = new Email
			{
				DateTime = dateTimeNow,
				Headers = new() { header },
				FromName = emailManager.EmailName,
				FromAddress = emailManager.EmailAddress,
				ToName = userFullname,
				ToAddress = user.Email,
				Subject = subject,
				Text = text
			};

			await emailManager.SendEmailAsync(emailForWinner);
		}

		private async Task NotifyWinnerAsync(
			DateTime dateTimeNow,
			AuctionBid maxAuctionBid,
			User auctionWinner,
			string auctionWinnerFullname
		)
		{
			var autogeneratedMessage =
				await api.GetAutogeneratedMessageAsync(AutogeneratedMessage.For.AuctionWinner);

			var auctionSummary = new AuctionSummary(maxAuctionBid.AuctionOffer, maxAuctionBid);

			var subject = autogeneratedMessage.FormatSubject(auctionSummary);
			var message = autogeneratedMessage.FormatMessage(auctionSummary);

			await NotifyUserAsync(dateTimeNow, auctionWinner, auctionWinnerFullname, subject, message);
		}

		private async Task NotifyLoserAsync(
			DateTime dateTimeNow,
			User auctionLoser,
			string auctionLoserFullname,
			string subject,
			string message
		)
		{
			await NotifyUserAsync(dateTimeNow, auctionLoser, auctionLoserFullname, subject, message);
		}

		private async Task<(List<string> FormattedSubjects, List<string> FormattedMessages)> GetFormattedSubjectsAndMessagesAsync(
			List<AuctionBid> auctionBids,
			AuctionBid winnerAuctionBid
		)
		{
			var autogeneratedMessage =
				await api.GetAutogeneratedMessageAsync(AutogeneratedMessage.For.AuctionLoser);

			var auctionSummaries = new List<AuctionSummary>(auctionBids.Count);
			for (int i = 0; i < auctionBids.Count; i++)
			{
				var auctionSummary = new AuctionSummary(winnerAuctionBid.AuctionOffer, auctionBids[i], winnerAuctionBid);
				auctionSummaries.Add(auctionSummary);
			}

			var formattedSubjects = autogeneratedMessage.FormatSubject(auctionSummaries);
			var formattedMessages = autogeneratedMessage.FormatMessage(auctionSummaries);

			return (formattedSubjects, formattedMessages);
		}

		private async Task NotifyLosersAsync(
			DateTime dateTimeNow,
			List<AuctionBid> lostAuctionBids,
			AuctionBid maxAuctionBid
		)
		{
			var (formattedSubjects, formattedMessages) = await GetFormattedSubjectsAndMessagesAsync(lostAuctionBids, maxAuctionBid);

			var tasks = new List<Task>(lostAuctionBids.Count);

			for (int i = 0; i < lostAuctionBids.Count; i++)
			{
				var auctionLoser = lostAuctionBids[i].User;
				var loserFullname = $"{auctionLoser.Name} {auctionLoser.Surname}";

				var task = NotifyLoserAsync(dateTimeNow, auctionLoser, loserFullname, formattedSubjects[i], formattedMessages[i]);

				tasks.Add(task);
			}

			await Task.WhenAll(tasks.ToArray());
		}

		private async Task EvaluateAuctionOffersAsync(
			DateTime dateTimeNow,
			List<AuctionOffer> endedAuctionOffers
		)
		{
			foreach (var offer in endedAuctionOffers)
			{
				var maxAuctionBid = await api.GetMaxAuctionBidAsync(offer.Id);
				if (maxAuctionBid is null)
				{// there were no bids (no participants)
					await NotifyAdminAuctionEndedWithoutWinnerAsync(dateTimeNow, offer);
					offer.OfferEnd += TimeSpan.FromDays(7);
				}
				else
				{
					var auctionWinner = maxAuctionBid.User;
					var auctionWinnerFullname = $"{auctionWinner.Name} {auctionWinner.Surname}";

					var notifyWinner = NotifyWinnerAsync(dateTimeNow, maxAuctionBid, auctionWinner, auctionWinnerFullname);

					var notifyAdmin = NotifyAdminAuctionEndedWithWinnerAsync(dateTimeNow, maxAuctionBid, auctionWinner, auctionWinnerFullname);

					var lostAuctionBids = await api.GetLostAuctionBidsAsync(offer.Id);
					var notifyLosers = NotifyLosersAsync(dateTimeNow, lostAuctionBids, maxAuctionBid);
				
					offer.IsEvaluated = true;

					await Task.WhenAll(notifyWinner, notifyAdmin, notifyLosers);
				}

				await api.SaveAuctionOfferAsync(offer);
			}
		}

		private async Task<List<AuctionOffer>> GetEndedAuctionOffersAsync(DateTime dateTimeNow, bool includeEvaluated = true)
		{
			var auctionOffers = await api.GetAuctionOffersAsync();

			var auctionOffersEnded = auctionOffers
				.Where(ao => (ao.OfferEnd < dateTimeNow) && (includeEvaluated || !ao.IsEvaluated))
				.ToList();

			return auctionOffersEnded;
		}

		private void RegisterEventHandler()
		{
			updateEvent += async () =>
			{
				if (isEvaluationInProgress)
				{
					/* We don't want to start a new evaluation if the preceding one is still in progress, 
					* it may cause some problems like sending multiple (even blank) emails. This shouln't happen as there is not too small interval set, 
					* but due to defensive programming this kind of precaution is being made. Keep in mind that because of the mentioned interval, we dont need locks,
					* the bool field should be sufficient. */
					return;
				}

				var dateTimeNow = DateTime.Now;
				var endedAuctionOffers = await GetEndedAuctionOffersAsync(dateTimeNow, includeEvaluated: false);
				if (endedAuctionOffers.Count == 0 || isEvaluationInProgress)
				{
					return;
				}

				try
				{
					isEvaluationInProgress = true;
					await EvaluateAuctionOffersAsync(dateTimeNow, endedAuctionOffers);
				}
				catch (Exception ex)
				{
					var ids = endedAuctionOffers.Select(ao => ao.Id);

					logger.LogCritical(ex, "Failed to evaluate auction offers with ids: {AuctionOffersIds}.", ids);
				}
				finally
				{
					isEvaluationInProgress = false;
				}
			};
		}
	}
}

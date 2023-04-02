﻿namespace ServISData.Attributes
{
	internal class AutogeneratedMessageDataAttribute : Attribute
	{
		public string Label { get; }
		public string DefaultSubject { get; }
		public string DefaultMessage { get; }
		public string[] Tags { get; }

		public AutogeneratedMessageDataAttribute(string label, string defaultSubject, string defaultMessage, string[] tags)
		{
			Label = label;
			DefaultSubject = defaultSubject;
			DefaultMessage = defaultMessage;
			Tags = tags;
		}
	}
}

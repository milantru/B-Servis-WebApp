using ServISData;
using ServISData.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Authorization;
using ServISWebApp.Auth;
using Syncfusion.Licensing;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;
using ServISWebApp.Shared;
using ServISWebApp.BackgroundServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ProtectedLocalStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddDbContextFactory<ServISDbContext>(options =>
	{
		var connectionString = ServISDbContextFactory.GetConnectionString();
		options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
	}
);
builder.Services.AddSingleton<IServISApi, ServISApi>();
builder.Services.AddScoped<SfDialogService>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
builder.Services.AddSingleton<EmailManager>(provider =>
{
	var config = provider.GetRequiredService<IConfiguration>();
	var emailName = config.GetValue<string>("EmailName");
	var emailAddress = config.GetValue<string>("EmailAddress");
	var emailPassword = config.GetValue<string>("EmailAppPassword");
	return new(emailName, emailAddress, emailPassword);
});
builder.Services.AddHostedService<EverySecondTimerService>();
builder.Services.AddHostedService<AuctionEvaluatorService>(provider =>
{
	var emailManager = provider.GetRequiredService<EmailManager>();
	var api = provider.GetRequiredService<IServISApi>();
	var baseUrl = provider.GetRequiredService<IConfiguration>().GetValue<string>("AppBaseUrl");
	return new(api, emailManager, baseUrl);
});

var app = builder.Build();

app.UseRequestLocalization("sk");

// Register Syncfusion license
var syncfusionLicenceKey = builder.Configuration["SyncfusionLicenceKey"];
SyncfusionLicenseProvider.RegisterLicense(syncfusionLicenceKey);

// Apply migration
var factory = app.Services.GetService<IDbContextFactory<ServISDbContext>>();
factory?.CreateDbContext().Database.Migrate();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

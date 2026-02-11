using Microsoft.Extensions.Options;
using NewsletterIntelligence;
using NewsletterIntelligence.Domain.Configurations;
using NewsletterIntelligence.Infrastructure.Clients;
using NewsletterIntelligence.Infrastructure.Clients.Interfaces;
using NewsletterIntelligence.Infrastructure.Services;
using NewsletterIntelligence.Infrastructure.Services.Interfaces;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

// Map settings
builder.Services
    .AddOptions<ImapSettings>()
    .Bind(builder.Configuration.GetSection("Imap"))
    .ValidateOnStart();

// Dependency Injection
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IMailKitClient, MailKitClient>();

builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<ImapSettings>>().Value);

var host = builder.Build();
host.Run();
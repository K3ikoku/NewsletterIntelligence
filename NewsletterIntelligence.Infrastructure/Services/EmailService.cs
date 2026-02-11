using NewsletterIntelligence.Domain.Entities;
using NewsletterIntelligence.Infrastructure.Clients.Interfaces;
using NewsletterIntelligence.Infrastructure.Services.Interfaces;

namespace NewsletterIntelligence.Infrastructure.Services;

public class EmailService(IMailKitClient mailKitClient) : IEmailService
{
    public async Task<IEnumerable<Email>> GetAndCleanEmails()
    {
        var emails = await mailKitClient.GetEmails();

        return null!;
    }
}
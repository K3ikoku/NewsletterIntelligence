using MimeKit;

namespace NewsletterIntelligence.Infrastructure.Clients.Interfaces;

public interface IMailKitClient
{
    Task<IEnumerable<MimeMessage>> GetEmails();
}
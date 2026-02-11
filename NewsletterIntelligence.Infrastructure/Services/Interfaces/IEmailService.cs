using NewsletterIntelligence.Domain.Entities;

namespace NewsletterIntelligence.Infrastructure.Services.Interfaces;

public interface IEmailService
{
    Task<IEnumerable<Email>> GetAndCleanEmails();
}
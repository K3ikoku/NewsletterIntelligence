using Microsoft.AspNetCore.Mvc;
using NewsletterIntelligence.Infrastructure.Services.Interfaces;

namespace NewsletterIntelligence.Api;

[ApiController]
[Route("[controller]")]
public class NewsletterController(IEmailService emailService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> RunEmail()
    {
        var emails = await emailService.GetAndCleanEmails();
        return Ok(emails);
    }
}
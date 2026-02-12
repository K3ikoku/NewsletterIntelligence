using AngleSharp;
using AngleSharp.Dom;
using MimeKit;
using NewsletterIntelligence.Domain.Entities;

namespace NewsletterIntelligence.Infrastructure.Utilities;

public static class EmailBodyExtractor
{
    public static async Task<IEnumerable<EmailSection>> ExtractBySender(string sender, MimeMessage message)
    {
        // Get the HTML body
        var htmlBody = message.HtmlBody ?? message.TextBody ?? "";

        if (string.IsNullOrWhiteSpace(htmlBody))
            return new List<EmailSection>();

        // Parse HTML into AngleSharp DOM
        var context = BrowsingContext.New(Configuration.Default);
        var document = await context.OpenAsync(req => req.Content(htmlBody));
        var root = document.Body;

        if (root is null)
            return new List<EmailSection>();

        return sender switch
        {
            "Geopolitics Daily" => await GeopoliticsExtractor.ExtractSections(root),
            "Världens Historia" => await VarldensHistoriaExtractor.ExtractSections(root),
            "Illustrerad Vetenskap" => await IllustreradVetenskapExtractor.ExtractSections(root),
            not null when sender.StartsWith("TLDR") => await TLDRExtractor.ExtractSections(root),
            _ => ExtractGeneric(root)
        };
    }

    private static IEnumerable<EmailSection> ExtractGeneric(IElement root)
    {
        throw new NotImplementedException();
    }
}
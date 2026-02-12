namespace NewsletterIntelligence.Domain.Entities;

public sealed record Email
{
    public required string EmailSender { get; init; }
    public required string Subject { get; init; } //TODO: Do i want this? 
    public required IEnumerable<EmailSection> Sections { get; init; }
    public required DateTimeOffset DateReceived { get; init; }
    public required string EmailUuid { get; init; }
}

public sealed record EmailSection
{
    public required string Header { get; init; }
    public required string Text { get; init; }
    public required List<(string Href, string Text)> Links { get; set; } = [];
}
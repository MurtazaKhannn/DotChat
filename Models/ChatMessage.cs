namespace Chat.API.Models;

public class ChatMessage
{
    public long Id { get; set; }
    public required string Content { get; set; } 
    public DateTimeOffset Timestamp { get; set; }
    public Guid? AuthorId { get; set; } 
    public string? Author { get; set; } = null!;
    public Guid ConversationId { get; set; }
    public Conversation Conversation { get; set; } = null!;
}

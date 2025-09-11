namespace Chat.API.Models;

public class Conversation
{
    public Guid Id { get; set; } // A unique ID for each conversation
    public string? Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public ICollection<ChatMessage> Messages { get; set; } = [];
    public ICollection<ConversationParticipant> Participants { get; set; } = [];
}
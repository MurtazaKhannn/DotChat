using Microsoft.VisualBasic;

namespace Chat.API.Models;

public class ConversationParticipant
{
    public Guid UserId { get; set; } // Foreign key to User
    public User User { get; set; } = null!;
    public Guid ConversationId { get; set; } // Foreign key to Conversation
    public Conversation Conversation { get; set; } = null!;
}

using Microsoft.AspNetCore.Identity;

namespace Chat.API.Models;

public class User : IdentityUser<Guid>
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required byte[] PasswordHash { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public bool IsOnline { get; set; }
    public ICollection<ConversationParticipant> ConversationParticipants { get; set; } = [];

}
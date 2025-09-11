using Chat.API.Data;
using Chat.API.Models;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using System.Threading.Tasks;
namespace Chat.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;
        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SendMessage(string message)
        {
            var userName = Context?.User?.Identity?.Name;
            var userId = Context?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            var chatMessage = new ChatMessage
            {
                AuthorId = Guid.TryParse(userId, out var parsedId) ? parsedId : Guid.Empty,
                Author = userName ?? "Anonymous",
                Content = message,
                Timestamp = DateTimeOffset.UtcNow
            };

            _context.Messages.Add(chatMessage);
            await _context.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveMessage", userName, message);
        }
    }
}

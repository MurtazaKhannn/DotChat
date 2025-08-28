using Chat.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.API.Data
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }

        public DbSet<ChatMessage> Messages { get; set; }
    }
}

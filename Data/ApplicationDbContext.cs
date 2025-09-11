using Chat.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ChatMessage> Messages { get; set; }
    }
}

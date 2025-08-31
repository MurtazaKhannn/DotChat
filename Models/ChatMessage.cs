namespace Chat.API.Models
{
    public class ChatMessage
    {
        public long Id { get; set; }
        public required string UserId { get; set; }
        public required string User { get; set; }
        public required string Message { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}

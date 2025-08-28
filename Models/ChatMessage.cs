namespace Chat.API.Models
{
    public class ChatMessage
    {
        public long Id { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}

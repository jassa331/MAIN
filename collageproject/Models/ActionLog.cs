namespace collageproject.Models
{
    public class ActionLog
    {
        public int Id { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? UserName { get; set; }
        public string? UserIp { get; set; }
        public DateTime Timestamp { get; set; }
        public double DurationMs { get; set; }
    }
}

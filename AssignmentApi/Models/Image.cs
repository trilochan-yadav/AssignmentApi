namespace AssignmentApi.Models
{
    public class Image
    {
        public string id { get; set; } = string.Empty;

        public string alt { get; set; } = string.Empty;

        public Detail? detail { get; set; }
    }
}

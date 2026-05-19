namespace AssignmentApi.Models
{
    public class Product
    {
        public string id { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;

        public List<Image> images { get; set; } = new();
    }
}

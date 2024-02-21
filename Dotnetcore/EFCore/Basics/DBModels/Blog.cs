namespace EFCoreBasics
{
    public class Blog
    {
        public int BlogId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty; 
        public int Rating { get; set; } = default;

        public List<Post>? Posts { get; set; } = default;
    }
}

using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore.Basics.LazyLoading
{
    public class Blog
    {
        public int BlogId { get; set; }

        public string Title { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }

        private ICollection<Post> _posts;
        public ICollection<Post> Posts
        {
            get => LazyLoader.Load(this, ref _posts);
            set => _posts = value;
        }

        public Blog()
        {
        }

        private Blog(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader { get; set; }
    }
}

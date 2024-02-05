using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore.Basics.LazyLoading
{
    public class LazyBlog
    {
        public int BlogId { get; set; }

        public string Title { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }

        private ICollection<LazyPost> _posts;
        public ICollection<LazyPost> Posts
        {
            get => LazyLoader.Load(this, ref _posts);
            set => _posts = value;
        }

        public LazyBlog()
        {
        }

        private LazyBlog(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader { get; set; }
    }
}

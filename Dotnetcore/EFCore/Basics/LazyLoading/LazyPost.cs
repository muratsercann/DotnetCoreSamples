using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore.Basics.LazyLoading
{
    public class LazyPost
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }

        private LazyBlog _blog;

        public LazyBlog Blog
        {
            get => LazyLoader.Load(this, ref _blog);
            set => _blog = value;
        }

        public LazyPost()
        {
        }

        private LazyPost(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader { get; set; }


    }
}

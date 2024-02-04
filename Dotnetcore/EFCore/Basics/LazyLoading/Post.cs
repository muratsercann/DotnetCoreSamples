using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore.Basics.LazyLoading
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }

        private Blog _blog;

        public Blog Blog
        {
            get => LazyLoader.Load(this, ref _blog);
            set => _blog = value;
        }

        public Post()
        {
        }

        private Post(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader { get; set; }


    }
}

using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Basics.LazyLoading
{
    public class LazyPost
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public int BlogId { get; set; }

        private LazyBlog? _blog = default;

        public LazyBlog? Blog
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

        private ILazyLoader? LazyLoader { get; set; }


    }
}

using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Basics.LazyLoading
{
    public class LazyBlog
    {
        public int BlogId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public int Rating { get; set; } = default;

        private ICollection<LazyPost>? _posts = default;
        public ICollection<LazyPost>? Posts
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

        private ILazyLoader? LazyLoader { get; set; }
    }
}

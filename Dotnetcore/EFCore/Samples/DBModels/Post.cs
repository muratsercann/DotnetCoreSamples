﻿using Microsoft.EntityFrameworkCore.Infrastructure;
namespace EFCoreSamples
{
    public class Post
    {
        public int PostId { get; set; }
        public int BlogId { get; set; } = default;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}

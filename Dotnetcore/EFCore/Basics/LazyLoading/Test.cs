namespace EFCore.Basics.LazyLoading
{
    public static class Test
    {
        public static void Run()
        {
            using (BloggingContext context = new BloggingContext())
            {
                var blogs = context.Blogs.ToList();
                var posts = blogs[0].Posts;//Load Posts from Db at here !

            }
        }
    }
}

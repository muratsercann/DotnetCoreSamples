namespace EFCore.Basics.LazyLoading
{
    public static class Test
    {
        public static void Run()
        {
            using (LazyContext context = new LazyContext())
            {
                var blogs = context.Blogs.ToList();
                var posts = blogs[0].Posts;//Load Posts from Db at here !

            }
        }
    }
}

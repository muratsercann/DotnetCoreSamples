using Microsoft.EntityFrameworkCore;

namespace EFCoreBasics
{
    class Program
    {
        public static readonly BloggingContext _dbContext;

        static Program()
        {
            _dbContext = new BloggingContext();
        }

        static void SeedData()
        {
            using (BloggingContext dbContext = new BloggingContext())
            {
                if (dbContext.Blogs.Any())
                {
                    return;
                }
                List<Blog> blogs = new List<Blog> {
                new Blog {
                    Url = "Url1",
                    Rating = 5,
                    Title = "My coding life 1",
                    Posts = new List<Post>
                    {
                        new Post(){BlogId = 1,Content = "Post 11 content..", Title = "Post 11" },
                        new Post(){BlogId = 1,Content = "Post 12 content..", Title = "Post 12" },
                        new Post(){BlogId = 1,Content = "Post 13 content..", Title = "Post 13" },
                        new Post(){BlogId = 1,Content = "Post 14 content..", Title = "Post 14" },
                    },

                },
                new Blog {
                    Url = "Url1",
                    Rating = 4,
                    Title = "My coding life 2",
                    Posts = new List<Post>
                    {
                        new Post(){BlogId = 2,Content = "Post 21 content..", Title = "Post 21" },
                        new Post(){BlogId = 2,Content = "Post 22 content..", Title = "Post 22" },
                        new Post(){BlogId = 2,Content = "Post 23 content..", Title = "Post 23" },
                        new Post(){BlogId = 2,Content = "Post 24 content..", Title = "Post 24" },
                    },

                }

                };

                foreach (var item in blogs)
                {
                    dbContext.Blogs.Add(item);

                }

                var x = dbContext.SaveChanges();
            }
        }
        static void Main()
        {
            try
            {
                //SeedData();

                //Lazy Loading
                EFCore.Basics.LazyLoading.Test.Run();

                //Eager Loading without proxies
                var blogs = _dbContext.Blogs.Include(blog => blog.Posts).ToList();
                var posts = blogs[0].Posts;

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                _dbContext.Dispose();
            }

            Console.WriteLine();
        }

    }
}
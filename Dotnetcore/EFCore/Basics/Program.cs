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
                        new Post(){BlogId = 1,Content = "LazyPost 11 content..", Title = "LazyPost 11" },
                        new Post(){BlogId = 1,Content = "LazyPost 12 content..", Title = "LazyPost 12" },
                        new Post(){BlogId = 1,Content = "LazyPost 13 content..", Title = "LazyPost 13" },
                        new Post(){BlogId = 1,Content = "LazyPost 14 content..", Title = "LazyPost 14" },
                    },

                },
                new Blog {
                    Url = "Url1",
                    Rating = 4,
                    Title = "My coding life 2",
                    Posts = new List<Post>
                    {
                        new Post(){BlogId = 2,Content = "LazyPost 21 content..", Title = "LazyPost 21" },
                        new Post(){BlogId = 2,Content = "LazyPost 22 content..", Title = "LazyPost 22" },
                        new Post(){BlogId = 2,Content = "LazyPost 23 content..", Title = "LazyPost 23" },
                        new Post(){BlogId = 2,Content = "LazyPost 24 content..", Title = "LazyPost 24" },
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

                //IQueryable<Post> queryable = _dbContext.Set<Post>();
                //var list2 = queryable.Skip(2).Take(3).ToList();
                IEnumerable<Post> enumerable = _dbContext.Set<Post>().Where(post => post.PostId > 1);
                var list = enumerable.Skip(2).Take(3).ToList();
                var list3 = enumerable.Where(x => x.BlogId == 3).ToList();
                var list4 = enumerable.AsQueryable().Where(x => x.BlogId == 3).ToList();
                string str = _dbContext.Set<Post>().Skip(1).Take(3).ToQueryString();

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
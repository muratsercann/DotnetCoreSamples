using EFCore.Samples;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace EFCoreSamples
{
    class Program
    {
        public static readonly BloggingContext _dbContext;

        static Program()
        {
            _dbContext = new BloggingContext();
        }

        static async Task Main()
        {
            char input;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Enter a character ('r' for read, 'w' for write): ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine(); // Move to the next line

                switch (input)
                {
                    case 'r':
                        Console.WriteLine("You chose 'r' - Read operation.");
                        //validInput = true;
                        await Write();
                        var blogs = await ReadAllBlogs();
                        Console.WriteLine($"Blogs readed count : {blogs.Count}");
                        break;
                    case 'w':
                        Console.WriteLine("You chose 'w' - Write operation.");
                        //validInput = true;
                        await Test_TransactionIsolationSerializable();

                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input. Please enter 'r' or 'w'.");
                        break;
                }
            }

            Console.ReadLine();
        }

        private async static Task<List<Blog>> GenerateDummyData(int count)
        {
            var blogs = new List<Blog>();
            var random = new Random();

            for (int i = 1; i <= count; i++)
            {
                var blog = new Blog
                {
                    Title = $"Blog {i}",
                    Url = $"http://example.com/blog{i}",
                    Rating = random.Next(1, 6), // Random rating between 1 and 5
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            Title = $"Post 1 for Blog {i}",
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                        },
                        new Post
                        {
                            Title = $"Post 2 for Blog {i}",
                            Content = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                        }
                    }
                };

                //blogs.Add(blog);
                _dbContext.Blogs.Add(blog);
                Console.Clear();
                Console.WriteLine($"{i} blogs created..");
                await _dbContext.SaveChangesAsync();
            }

            //foreach (var blog in blogs)
            //{
            //    _dbContext.Blogs.Add(blog);
            //}

            //await _dbContext.SaveChangesAsync();

            return blogs;
        }

        private async static Task Test_TransactionIsolationSerializable()
        {
            using (var context = new BloggingContext())
            {
                using (var transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable))
                {
                    //var blog = await context.Blogs.Take(1).FirstAsync();
                    //blog.Url = "url_" + Random.Shared.Next(0, int.MaxValue).ToString();
                    var num = Random.Shared.Next(0, int.MaxValue).ToString();
                    var blog = new Blog
                    {
                        Title = "Blog_" + num.ToString(),
                        Url = "Url_" + num.ToString(),
                        Rating = 1,
                    };
                    context.Blogs.Add(blog);

                    await Task.Delay(5000);

                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    Console.WriteLine($"a new Blog added, BlogId : {blog.BlogId}");
                }
            }
        }

        private async static Task Write()
        {
            using (var context = new BloggingContext())
            {
                using (var transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable))
                {
                    //var blog = await context.Blogs.Take(1).FirstAsync();
                    //blog.Url = "url_" + Random.Shared.Next(0, int.MaxValue).ToString();
                    var num = Random.Shared.Next(0, int.MaxValue).ToString();
                    var blog = new Blog
                    {
                        Title = "Blog_" + num.ToString(),
                        Url = "Url_" + num.ToString(),
                        Rating = 1,
                    };
                    context.Blogs.Add(blog);

                    //await Task.Delay(5000);

                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    Console.WriteLine($"a new Blog added, BlogId : {blog.BlogId}");
                }
            }
        }
        private async static Task<List<Blog>> ReadAllBlogs()
        {

            using (var context = new BloggingContext())
            {
                using (var transaction = await context.Database.BeginTransactionAsync())
                {
                    return await context.Blogs.ToListAsync();

                }
            }
        }

        ~Program()
        {
            _dbContext.Dispose();
        }
    }
}
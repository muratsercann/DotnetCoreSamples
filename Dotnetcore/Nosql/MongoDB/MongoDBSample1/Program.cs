using MongoDB.Driver;
using MongoDBSample1.Models;
using System.Data;
using static MongoDB.Driver.WriteConcern;
internal class Program
{
    static IMongoCollection<Blog> blogCollection;
    static readonly string dbname = "local";
    static readonly string connectionString = "mongodb://localhost:27017";

    private static async Task Main(string[] args)
    {

        var mongoClient = new MongoClient(connectionString);
        var db = mongoClient.GetDatabase(dbname);
        blogCollection = db.GetCollection<Blog>("Blog");


        //Get All Data
        var blogs = GetAllBlog();
        if (blogs.Count == 0)
        {
            await SeedBlogCollection();
            blogs = GetAllBlog();
        }

        WriteToConsole(blogs, "All Blogs : ");

        //await UpdateBlogAsync("Blog_12345", "Blog_1");

        Console.ReadLine();
    }

    private static List<Blog> GetAllBlog()
    {
        return blogCollection.AsQueryable().ToList();
    }

    private static Blog GetBlog(string id)
    {
        //var filter = Builders<Blog>.Filter.Eq("BlogId", id);
        return blogCollection.Find(b => b.BlogId == id).FirstOrDefault();
    }

    private static async Task<UpdateResult?> UpdateBlogAsync(string oldTitle, string newTitle)
    {
        //var filter = Builders<Blog>.Filter.Eq(blog => blog.Title, oldTitle);
        var filter = Builders<Blog>.Filter.Regex(blog => blog.Title, oldTitle);

        var update = Builders<Blog>.Update.Set(blog => blog.Title, newTitle);

        var result = await blogCollection.UpdateOneAsync(filter, update);

        return result;
    }
    private static void AddBlog(Blog blog)
    {
        blogCollection.InsertOne(blog);
    }

    private static async Task SeedBlogCollection()
    {
        var blogList = new List<Blog>();
        for (int i = 1; i <= 150; i++)
        {
            blogList.Add(new Blog
            {
                Title = $"Blog_{i}",
                Url = $"http://example.com/blog/Blog_{i}",
                Rating = (i % 5) + 1
            });
        }

        await blogCollection.InsertManyAsync(blogList);
    }
    private static void WriteToConsole(List<Blog> blogs, string message = "")
    {
        Console.WriteLine($"{message}");
        foreach (var item in blogs)
        {
            WriteToConsole(item);
        }
    }

    private static void WriteToConsole(Blog blog)
    {
        if (blog is null)
        {
            return;
        }
        Console.WriteLine($"id : {blog.BlogId}, : title : {blog.Title}, url : {blog.Url}, rating : {blog.Rating}");
    }
}

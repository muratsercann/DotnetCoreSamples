using MongoDB.Driver;
using MongoDBSample1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBSample1.Services
{
    public class BlogService
    {
        static IMongoCollection<Blog>? blogCollection;
        static readonly string dbname = "local";
        static readonly string connectionString = "mongodb://localhost:27017";

        public BlogService()
        {

            var mongoClient = new MongoClient(connectionString);
            var db = mongoClient.GetDatabase(dbname);
            blogCollection = db.GetCollection<Blog>(nameof(Blog));

        }

        public async Task<Blog?> GetBlogAsync(string id)
        {
            if (blogCollection is null)
            {
                return null;
            }

            return await blogCollection.Find(b => b.BlogId == id).FirstOrDefaultAsync();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            if (blogCollection is null)
            {
                return new List<Blog>();
            }

            return await blogCollection.AsQueryable().ToListAsync();
        }

        public async Task InsertBlogAsync(Blog blog)
        {
            if (blogCollection is null)
            {
                return;
            }

            await blogCollection.InsertOneAsync(blog);
        }
    }
}

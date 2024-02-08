using DapperBasicSample.DBModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Basics.Services
{
    interface IBlogService
    {
        IEnumerable<Blog> GetBlogs();
        IEnumerable<Blog> GetBlogsWithRelatedPosts();

        Blog? GetBlog(int id);
        Blog? GetBlogWithRelatedPosts(int id);

    }
    internal class BlogService : IBlogService
    {
        private readonly string connectionString;

        public BlogService(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public Blog? GetBlog(int id)
        {
            Blog? result;
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string query = $@"select * from Blogs Where BlogId = @P1";
                result = dbConnection.Query<Blog>(query, new { P1 = id }).FirstOrDefault();
            }
            return result;
        }

        public IEnumerable<Blog> GetBlogs()
        {
            IEnumerable<Blog> result = new List<Blog>();
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string query = $@"select * from Blogs";
                result = dbConnection.Query<Blog>(query);
            }
            return result;
        }

        public Blog? GetBlogWithRelatedPosts(int id)
        {
            Blog? result;
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string query = $@"select b.*, p.*  
                                  from Blogs b
                                  left join Posts p on b.BlogId = p.BlogId 
                                  where b.BlogId = @P1;";
                Blog? existingBlog = null;
                result = dbConnection.Query<Blog, Post, Blog?>(query, (blog, post) =>
                {
                    if (existingBlog == null)
                    {
                        existingBlog = blog;
                        existingBlog.Posts = new List<Post>();
                    }
                    post.Blog = blog;
                    existingBlog?.Posts?.Add(post);

                    return existingBlog;
                },
                new { P1 = id },
                splitOn: "PostId").FirstOrDefault();
            }
            return result;
        }

        public IEnumerable<Blog> GetBlogsWithRelatedPosts()
        {
            List<Blog> blogs = new List<Blog>();
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string query = $@"SELECT 
                    b.BlogId,
                    b.Title,
                    b.Url,
                    b.Rating,
                    p.PostId,
                    p.Title,
                    p.Content,
                    p.BlogId
                FROM Blogs b
                LEFT JOIN Posts p ON b.BlogId = p.BlogId";

                var costBlogDictionary = new Dictionary<int, Blog>();

                dbConnection.Query<Blog, Post, Blog?>(query, (blog, post) =>
                {
                    var existingBlog = blogs.Where(b => b.BlogId == blog.BlogId).FirstOrDefault();
                    if (existingBlog == null)
                    {
                        existingBlog = blog;
                        existingBlog.Posts = new List<Post>();
                        blogs.Add(existingBlog);
                    }

                    post.Blog = blog;
                    existingBlog?.Posts?.Add(post);

                    return existingBlog;
                },
                splitOn: "PostId");
            }
            return blogs;
        }


    }
}

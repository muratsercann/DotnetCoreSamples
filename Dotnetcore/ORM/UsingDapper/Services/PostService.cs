using DapperBasicSample.DBModels;
using System.Data;
using System.Data.SqlClient;

namespace Dapper.Basics.Services
{
    interface IPostService
    {
        IEnumerable<Post> GetPosts();
        IEnumerable<Post> GetPosts(int blogId);
        IEnumerable<Post> GetPostsWithRelatedBlogs();
        IEnumerable<Post> GetPostsWithRelatedBlogs(int blogId);

        Post? GetPost(int id);
        Post? GetPostWithRelatedBlog(int id);

    }
    public class PostService : IPostService
    {

        private readonly string connectionString;

        public PostService(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public Post? GetPost(int id)
        {
            Post? result;
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string query = $@"select * from Posts Where PostId = @P1";
                result = dbConnection.Query<Post>(query, new { P1 = id }).FirstOrDefault();
            }
            return result;
        }

        public Post? GetPostWithRelatedBlog(int id)
        {
            Post? result = null;
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string query = $@"select p.*,b.* 
                                 from Posts p 
                                 left join Blogs b on p.BlogId = b.BlogId
                                 where p.PostId = @P1
                                  ";

                result = dbConnection.Query<Post, Blog, Post>(query, (post, blog) =>
                {
                    post.Blog = blog;
                    return post;
                },
                new { P1 = id },
                splitOn: "BlogId").FirstOrDefault();
            }
            return result;
        }

        public IEnumerable<Post> GetPosts()
        {
            IEnumerable<Post> result = new List<Post>();
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string query = $@"select * from Posts";
                result = dbConnection.Query<Post>(query);
            }
            return result;
        }

        public IEnumerable<Post> GetPosts(int blogId)
        {
            IEnumerable<Post> result = new List<Post>();
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string query = $@"select * from Posts where blogId = @P1";
                result = dbConnection.Query<Post>(query, new { P1 = blogId });
            }
            return result;
        }

        public IEnumerable<Post> GetPostsWithRelatedBlogs()
        {
            IEnumerable<Post> posts = new List<Post>();
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string query = $@"select p.*,b.* 
                                 from Posts p 
                                 left join Blogs b on p.BlogId = b.BlogId";

                var costBlogDictionary = new Dictionary<int, Post>();

                posts = dbConnection.Query<Post, Blog, Post>(query, (post, blog) =>
                {
                    if (!costBlogDictionary.TryGetValue(post.PostId, out var existingPost))
                    {
                        existingPost = post;
                        existingPost.Blog = blog;
                        costBlogDictionary.Add(existingPost.PostId, existingPost);
                    }
                    return existingPost;
                },
                splitOn: "BlogId");
            }
            return posts;
        }

        public IEnumerable<Post> GetPostsWithRelatedBlogs(int blogId)
        {
            IEnumerable<Post> posts = new List<Post>();
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string query = $@"select p.*,b.* from Posts p 
                                 left join Blogs b on p.BlogId = b.BlogId 
                                 where p.BlogId = @P1;";

                var costBlogDictionary = new Dictionary<int, Post>();

                posts = dbConnection.Query<Post, Blog, Post>(query, (post, blog) =>
                {
                    if (!costBlogDictionary.TryGetValue(post.PostId, out var existingPost))
                    {
                        existingPost = post;
                        existingPost.Blog = blog;
                        costBlogDictionary.Add(existingPost.PostId, existingPost);
                    }
                    return existingPost;
                },
                new { P1 = blogId },
                splitOn: "BlogId"
                );
            }
            return posts;
        }


    }
}

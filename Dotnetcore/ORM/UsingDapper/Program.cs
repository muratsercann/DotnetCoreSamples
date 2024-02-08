using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Dapper;
using Dapper.Basics.Services;
using DapperBasicSample.DBModels;

namespace DapperBasicSample
{
    internal class Program
    {
        private static readonly string connectionString = "Server=localhost;Database=BlogDB;TrustServerCertificate=true;Trusted_Connection=True;";
        private static void Main(string[] args)
        {

            IBlogService blogService = new BlogService(connectionString);
            var b1 = blogService.GetBlogs();
            var b2 = blogService.GetBlogsWithRelatedPosts();

            var b3 = blogService.GetBlog(3);
            var b4 = blogService.GetBlogWithRelatedPosts(3);
            

            IPostService postService = new PostService(connectionString);
            var p1 = postService.GetPosts();
            var p2 = postService.GetPostsWithRelatedBlogs();

            var p3 = postService.GetPost(9);
            var p4 = postService.GetPostWithRelatedBlog(9);
           
            var p5 = postService.GetPosts(3);
            var p6 = postService.GetPostsWithRelatedBlogs(3);

            Console.ReadLine();
        }


    }

}
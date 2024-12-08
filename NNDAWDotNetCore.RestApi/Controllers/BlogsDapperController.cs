using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NNDAWDotNetCore.RestApi.DataModels;
using NNDAWDotNetCore.RestApi.ViewModels;
using System.Data;

namespace NNDAWDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsDapperController : ControllerBase
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User Id=sa;Password=sasa@123;TrustServerCertificate=True;";

        [HttpGet]
        public IActionResult GetBlogs()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_blog where deleteflag = 0;";

                var lst = db.Query<BlogViewModel>(query).ToList();
                return Ok(lst);
            }
        }

        //[HttpGet("{id}")]
        //public IActionResult GetBlog(int id)
        //{
            
        //}

        [HttpPost]
        public IActionResult CreateBlog(BlogViewModel blog)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

                int result = db.Execute(query, new
                {
                    BlogTitle = blog.Title,
                    BlogAuthor = blog.Author,
                    BlogContent = blog.Content
                });

                return Ok(result == 1 ? "Saving successful." : "Saving failed.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,BlogViewModel blog)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogID";

                int result = db.Execute(query, new
                {
                    BlogId = id,
                    BlogTitle = blog.Title,
                    BlogAuthor = blog.Author,
                    BlogContent = blog.Content
                });
                return Ok(result == 1 ? "Updating successful." : "Updating failed.");
            }
        }

        //[HttpPatch("{id}")]
        //public IActionResult PatchBlog(int id, TblBlog blog)
        //{
            
        //}

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $@"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";

                int result = db.Execute(query, new { BlogId = id });
                return Ok(result == 1 ? "Deleting Successful." : "Deleting Fail.");
            }
        }
    }
}

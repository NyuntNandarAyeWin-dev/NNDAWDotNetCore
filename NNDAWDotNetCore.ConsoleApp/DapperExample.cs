using Dapper;
using NNDAWDotNetCore.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NNDAWDotNetCore.ConsoleApp
{
    public class DapperExample
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User Id=sa;Password=sasa@123";
        
        public void Read()
        {
            //using(IDbConnection db = new SqlConnection(_connectionString))
            //{
            //    string query = "select * from tbl_blog where deleteflag = 0;";

            //    var lst = db.Query(query).ToList();
            //    foreach (var item in lst)
            //    {
            //        Console.WriteLine(item.BlogId);
            //        Console.WriteLine(item.BlogTitle);
            //        Console.WriteLine(item.BlogAuthor);
            //        Console.WriteLine(item.BlogContent);
            //    }
            //}

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_blog where deleteflag = 0;";

                var lst = db.Query<BlogDataModel>(query).ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }

        }

        public void Create(string title, string author, string content)
        {
            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)";

                int result = db.Execute(query, new
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content,
                });

                Console.WriteLine(result == 1? "Saving successful.": "Saving failed.");
            }
        }

        public void Edit (int id)
        {
            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_blog where deleteflag = 0 and BlogId = @BlogId;";

                var item = db.Query<BlogDataModel>(query, new BlogDataModel { BlogId = id, }).FirstOrDefault();
               //if (item == null)
                if (item is null)
                {
                    Console.WriteLine("No Data found");
                    return;
                }
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Update(int id, string title, string author, string content)
        {
            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogId = @BlogID";

                int result = db.Execute(query, new
                {
                    BlogId = id,
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content,
                });
                Console.WriteLine(result == 1 ? "Updating successful." : "Updating failed.");
            }
        }

        public void Delete(int id)
        {
            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $@"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";

                int result = db.Execute(query, new { BlogId = id });
                Console.WriteLine(result == 1 ? "Deleting Successful." : "Deleting Fail.");
            }
        }
    }
}

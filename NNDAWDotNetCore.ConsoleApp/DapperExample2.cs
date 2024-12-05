using Dapper;
using NNDAWDotNetCore.ConsoleApp.Models;
using NNDAWDotNetCore.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNDAWDotNetCore.ConsoleApp
{
    public class DapperExample2
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User Id=sa;Password=sasa@123;TrustServerCertificate=True;";
        private readonly DapperService _dapperService;

        public DapperExample2()
        {
            _dapperService = new DapperService(_connectionString);
        } 
        
        public void Read()
        {
                string query = "select * from tbl_blog where deleteflag = 0;";

                var lst = _dapperService.Query<BlogDapperDataModel>(query).ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
        }

        public void Create(string title, string author, string content)
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

                int result = _dapperService.Execute(query, new
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content,
                });

                Console.WriteLine(result == 1 ? "Saving successful." : "Saving failed.");
            
        }

        public void Update(int id, string title, string author, string content)
        {
           
                string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogId = @BlogID";

                int result = _dapperService.Execute(query, new
                {
                    BlogId = id,
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content,
                });
                Console.WriteLine(result == 1 ? "Updating successful." : "Updating failed.");
            
        }

        public void Edit(int id)
        {
                string query = "select * from tbl_blog where deleteflag = 0 and BlogId = @BlogId;";

                var item = _dapperService.QueryFirstOrDefault<BlogDataModel>(query, new BlogDataModel { BlogId = id, });
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

        public void Delete(int id)
        {
           
                string query = $@"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";

                int result = _dapperService.Execute(query, new { BlogId = id });
                Console.WriteLine(result == 1 ? "Deleting Successful." : "Deleting Fail.");
            
        }
    }
}

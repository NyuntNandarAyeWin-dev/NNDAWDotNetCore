using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNDAWDotNetCore.ConsoleApp3
{
    public class RefitExample
    {
        public async Task Run()
        {
            var blogApi = RestService.For<IBlogApi>("https://localhost:7227");
            var lst = await blogApi.GetBlog();
            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogTitle);
            }

            //var item2 = await blogApi.GetBlog(1);
            //try
            //{
            //    var item3 = await blogApi.GetBlog(109);
            //}
            //catch (ApiException ex)
            //{
            //    if(ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            //    {
            //        Console.WriteLine("No data found!");
            //    }
            //}

            //var item4 = await blogApi.CreateBlog(new BlogModel
            //{
            //    BlogTitle = "test",
            //    BlogAuthor = "test",
            //    BlogContent = "test",
            //});

            //try
            //{
            //    var item5 = await blogApi.UpdateBlog(30, new BlogModel
            //    {
            //        BlogTitle = "update test",
            //        BlogAuthor = "update test",
            //        BlogContent = "update test",
            //    });
            //    Console.WriteLine(item5.BlogTitle);
            //    Console.WriteLine(item5.BlogAuthor);
            //    Console.WriteLine(item5.BlogContent);
            //}
            //catch (ApiException ex)
            //{
            //    if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            //    {
            //        Console.WriteLine("No data found!");
            //    }
            //}
        }
    }
}

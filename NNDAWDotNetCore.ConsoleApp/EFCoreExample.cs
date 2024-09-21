using Microsoft.EntityFrameworkCore;
using NNDAWDotNetCore.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NNDAWDotNetCore.ConsoleApp
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContent db = new AppDbContent();
            var lst = db.Blogs.Where(x => x.DeleteFlag == false).ToList();
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
            BlogDataModel blog = new BlogDataModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,

            };
            AppDbContent db = new AppDbContent();
            db.Blogs.Add(blog);
            var result = db.SaveChanges();

            Console.WriteLine(result == 1 ? "Saving successful." : "Saving failed.");
        }

        public void Edit(int id)
        {
            AppDbContent db = new AppDbContent();
            //db.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if(item is null)
            {
                Console.WriteLine("No data found");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

        }

        public void Update(int id, string title, string author, string content)
        {
            AppDbContent db = new AppDbContent();
            //db.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
            var item = db.Blogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            if (!string.IsNullOrEmpty(title))
            {
                item.BlogTitle = title;
            }
            if (!string.IsNullOrEmpty(author))
            {
                item.BlogAuthor = author;
            }
            if (!string.IsNullOrEmpty(content))
            {
                item.BlogContent = content;
            }

            db.Entry(item).State = EntityState.Modified;
            var result = db.SaveChanges();
            Console.WriteLine(result==1? "Updating successful.": "Updating failed.");
        }

        public void Delete(int id)
        {
            AppDbContent db = new AppDbContent();
            var item = db.Blogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            db.Entry(item).State = EntityState.Deleted;
            var result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Deleting successful." : "Deleting failed.");
        }
    }
}

// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using NNDAWDotNetCore.Database.Models;
using System;
using System.Net.Http.Headers;

Console.WriteLine("Hello, World!");

//AppDbContext db = new AppDbContext();
//var lst = db.TblBlogs.ToList();

//foreach(var item in lst)
//{
//    Console.WriteLine(item.BlogId);
//    Console.WriteLine(item.BlogTitle);
//    Console.WriteLine(item.BlogAuthor);
//    Console.WriteLine(item.BlogContent);
//}

var blog = new BlogModel
{
    Id = 1,
    Title = "Test Title",
    Author = "Test Author",
    Content = "Test Contest",
};

// Encode, Decode, Encryption, Decryption

// Encode , Encryption => SerializeObject { C# to Json }
// Decode , Decryption => DeserializeObject { Json to C# }

//string jsonStr = JsonConvert.SerializeObject(blog, Formatting.Indented);
string jsonStr = blog.ToJson();

Console.WriteLine(jsonStr);

string jsonStr2 = "{\"Id\":1,\"Title\":\"Test Title\",\"Author\":\"Test Author\",\"Content\":\"Test Contest\"}";
var blog2 = JsonConvert.DeserializeObject<BlogModel>(jsonStr2);
Console.WriteLine(blog2.Title);

//System.Text.Json.JsonSerializer.Serialize(jsonStr); => case sensitive
//System.Text.Json.JsonSerializer.Deserialize<BlogModel>(jsonStr2); => case sensitive

Console.ReadLine();

public class BlogModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }
}

public static class Extensions //Dev Code
{
    public static string ToJson(this object obj)
    {
        string jsonStr = JsonConvert.SerializeObject(obj, Formatting.Indented);
        return jsonStr;
    }
}
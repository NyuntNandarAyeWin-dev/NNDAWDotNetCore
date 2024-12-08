// See https://aka.ms/new-console-template for more information
using NNDAWDotNetCore.ConsoleApp3;

Console.WriteLine("Hello, World!");


//get
//post
//put
//patch
//delete

//resource
//endpoint

//HttpClient client = new HttpClient();
//var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
//if (response.IsSuccessStatusCode)
//{
//    string jsonStr = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(jsonStr);
//}

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Read();

//await httpClientExample.Edit(2);
//await httpClientExample.Edit(209);

//await httpClientExample.Create(5, "Test Title", "Test Body");

//await httpClientExample.Update(1, 10, "Test Title", "Test Body");

//await httpClientExample.Delete(100);

RestClientExample restClientExample = new RestClientExample();
await restClientExample.Create(3, "Title 3", "Body 3");

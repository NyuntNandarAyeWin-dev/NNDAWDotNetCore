// See https://aka.ms/new-console-template for more information
using NNDAWDotNetCore.ConsoleApp;
using System;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Console.ReadLine();

//ADO.Net
//Dapper (ORM)
//EFCore / Entity Framework (ORM)
//ORM => Object Relational Mapping
//nuget.org


//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Edit();
//adoDotNetExample.Update();
//adoDotNetExample.Delete();

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Create("Title", "Author", "Content");
//dapperExample.Update(4, "Title1", "Author1", "Content1");
//dapperExample.Update(20, "Title1", "Author1", "Content1");
//dapperExample.Delete(15);
//dapperExample.Edit(25);
//dapperExample.Edit(5);

DapperExample2 dapperExample2 = new DapperExample2();
dapperExample2.Read();

//EFCoreExample eFCoreExample = new EFCoreExample();
////eFCoreExample.Read();
////eFCoreExample.Create("Title", "Author", "Content");
////eFCoreExample.Edit(2);
////eFCoreExample.Edit(4);
////eFCoreExample.Update(5, "aa", "bb", "cc");
////eFCoreExample.Update(8, "Title1", "Author1", "Content1");
//eFCoreExample.Delete(3);

Console.ReadKey();

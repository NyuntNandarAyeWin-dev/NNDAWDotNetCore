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


AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Edit();
//adoDotNetExample.Update();
adoDotNetExample.Delete();

Console.ReadKey();
# NNDAWDotNetCore

Day1
============
WriteLine(value)
ReadLine()
ReadKey()

readme.md
md => markdown

for feature => add commit
feat: add somethings

for documents => add commit
docs: add somethings

Day2
==========
C# <=> Database
ADO.NET
//Dapper (ORM)
//EFCore / Entity Framework (ORM)

ORM => object relational mapping {C# => sql query}

//nuget.org

current project layer > right click > Browse > search box > sqlclient > system.Data.SqlClient > install

//Ctr + . => using System.Data.SqlClient;

connect db => connectionString("Data Source = server_name; Initial Catalog = db_name; User ID = sa; Password = sasa@123;");
SqlConnection connection = new SqlConnection("connectionString");

connection.Open();

break point => F9 {current line -> doesn't work, next line -> execute}
start debugging => F5
without debugging => Ctr + F5
one line go => F10

DB & C#
-------------------
query => SqlCommand
multi line support in C# => @"----"
store query run result => SqlDataAdapter
data receivable place => DataTable
execute in db => fill {adapter.fill()}
store multi data table => DataSet
{DataSet, DataTable,DataRow,DataColumn}

SqlCommand cmd = new SqlCommand(query,connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.fill(dt);

connection.Close();

foreach (DataRow dr in dt.Rows)
{
	Console.WriteLine (dr["----"]);
}

//ado.net

connection opening time => If read data => SqlDataReader

SqlDataReader reader = cmd.ExecuteReader();
while(reader.Read()){
	Console.WriteLine (reader["----"]);
}

Day 3
===========

ADO.NET

SqlInjection, so should be used sql parameter

data read  => SqlDataApapter, SqlDataReader

run => SqlCommand.ExecuteNonQuery => return int {count}

Class 
--------
project layer > right click > Add > Class

readonly => cann't edit more
declar variable inner class => starts with _ and small letter {_nameName}

dotnet tool install --global dotnet-ef --version 7

dotnet ef dbcontext scaffold "Server=.;Database=DotNetTrainingBatch5;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -t TblName -f

Json
var a = {"name" : "mg mg"}
a.name

JavaScript
var a = {name : "mg mg"}
a.name

=> javascript object doesn't work within json file


Postman

CRUD
1. Get		-> read
2. Post		-> create
3. Put		-> update
4. Patch	-> update
5. Delete	-> delete

endpoint
https://localhost:3000/api/blog

jsonplaceholder.typicode.com


Open api -> swagger 

IActionResult => can return json,file,view

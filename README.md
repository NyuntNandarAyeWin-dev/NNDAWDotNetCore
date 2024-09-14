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
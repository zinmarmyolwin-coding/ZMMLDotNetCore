// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using ZMMLDotNetCore.ConsoleApp.EFCoreExamples;

Console.WriteLine("Hello, World!");

//SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
//stringBuilder.DataSource = ".";
//stringBuilder.InitialCatalog = "DotNetTraning";
//stringBuilder.UserID = "sa";
//stringBuilder.Password = "sa@123";
//stringBuilder.TrustServerCertificate = true;

//SqlConnection sqlConnection = new SqlConnection(stringBuilder.ConnectionString);
//sqlConnection.Open();

//string query = "select * from Tbl_Blog;";
//SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
//SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
//DataTable dt = new DataTable();
//sqlDataAdapter.Fill(dt);



//sqlConnection.Close();

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine("Blog Id => " + dr["BlogId"]);
//    Console.WriteLine("Blog Title => " + dr["Title"]);
//    Console.WriteLine("Blog Author => " + dr["Author"]);
//    Console.WriteLine("Blog Content => " + dr["Content"]);
//    Console.WriteLine("--------------------------------------");
//}


#region AdoDotNet

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("TestTitle", "TestAuthor", "TestContent");
//adoDotNetExample.Update(8, "Update", "Update", "Update");
//adoDotNetExample.Delete(8);
//adoDotNetExample.Edit(7);

#endregion

#region Dapper

//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

#endregion

#region EFCore

EfCoreExample efCoreExample = new EfCoreExample();
efCoreExample.Run();

#endregion


Console.ReadKey();

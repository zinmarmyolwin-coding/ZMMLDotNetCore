using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZMMLDotNetCore.ConsoleApp.Model;
using ZMMLDotNetCore.ConsoleApp.Services;

namespace ZMMLDotNetCore.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        public void Run()
        {
            Update(1, "UpdateDap", "UpdateDap", "UpdateDap");
            Delete(1);
        }

        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            db.Open();
            List<BlogModel> model = db.Query<BlogModel>("select * from Tbl_Blog").ToList();
            foreach (BlogModel item in model)
            {
                Console.WriteLine($"BlogID : {item.BlogId}");
                Console.WriteLine($"BlogTitle : {item.Title}");
                Console.WriteLine($"BlogAuthor : {item.Author}");
                Console.WriteLine($"BlogContent : {item.Content}");
                Console.WriteLine("-------------------------------");
            }
        }

        private void Create(string blogTitle, string blogAuthor, string blogContent)
        {
            var item = new BlogModel
            {
                Title = blogTitle,
                Author = blogAuthor,
                Content = blogContent
            };
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            db.Open();
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            var result = db.Execute(query, item);
            string message = result > 0 ? "Create successful" : "Create fail.";
            Console.WriteLine(message);
        }

        private void Edit(int id)
        {
            IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            string message = string.Empty;
            db.Open();
            //BlogModel? model = db.Query<BlogModel>("select * from Tbl_Blog where BlogId=@BlogId ", id).FirstOrDefault(); // error scalar variable declear
            BlogModel? model = db.Query<BlogModel>("select * from Tbl_Blog where BlogId=@BlogId ", new BlogModel { BlogId = id })
                .FirstOrDefault();
            if (model == null)
            {
                message = "No Data Found.";
            }

            Console.WriteLine($"BlogID : {model.BlogId}");
            Console.WriteLine($"BlogTitle : {model.Title}");
            Console.WriteLine($"BlogAuthor : {model.Author}");
            Console.WriteLine($"BlogContent : {model.Content}");
            Console.WriteLine("-------------------------------");
        }

        private void Update(int id, string blogTitle, string blogAuthor, string blogContent)
        {
            var item = new BlogModel
            {
                BlogId = id,
                Title = blogTitle,
                Author = blogAuthor,
                Content = blogContent
            };
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            db.Open();
            string query = @"UPDATE [dbo].[Tbl_Blog]
            SET [BlogTitle] = @BlogTitle
              ,[BlogAuthor] = @BlogAuthor
              ,[BlogContent] = @BlogContent
             WHERE BlogId = @BlogId";
            var result = db.Execute(query, item);
            string message = result > 0 ? "Update successful" : "Update fail.";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            db.Open();
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                            WHERE BlogId = @BlogId";
            var result = db.Execute(query, new BlogModel { BlogId = id });
            string message = result > 0 ? "Delete successful" : "Delete fail.";
            Console.WriteLine(message);

        }
    }
}

using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZMMLDotNetCore.ConsoleApp.Model;

namespace ZMMLDotNetCore.ConsoleApp.EFCoreExamples
{
    internal class EfCoreExample
    {
        private readonly AppDbContext db = new AppDbContext();
        public void Run()
        {
            Read();
            Edit(1);
            Create("Efcore1", "Efcore1", "Efcore1");
            Update(2, "Efcoreup", "ip", "dc");
            Delete(5);
        }
        private void Read()
        {
            var result = db.Blogs.ToList();
            if (result.Count > 0)
            {
                foreach (BlogModel item in result)
                {
                    Console.WriteLine($"BlogID : {item.BlogId}");
                    Console.WriteLine($"BlogTitle : {item.Title}");
                    Console.WriteLine($"BlogAuthor : {item.Author}");
                    Console.WriteLine($"BlogContent : {item.Content}");
                    Console.WriteLine("-------------------------------");
                }
            }
        }

        private void Edit(int id)
        {
            string message = string.Empty;
            var result = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (result is null)
            {
                message = "No Data Found.";
                goto Result;
            }
            Console.WriteLine($"BlogID : {result.BlogId}");
            Console.WriteLine($"BlogTitle : {result.Title}");
            Console.WriteLine($"BlogAuthor : {result.Author}");
            Console.WriteLine($"BlogContent : {result.Content}");
            Console.WriteLine("-------------------------------");
        Result:
            Console.WriteLine(message);
        }

        private void Create(string blogTitle, string blogAuthor, string blogContent)
        {
            string message = string.Empty;
            var item = new BlogModel
            {
                Title = blogTitle,
                Author = blogAuthor,
                Content = blogContent
            };
            db.Blogs.Add(item);
            var rsult = db.SaveChanges();
            message = rsult > 0 ? "Create success" : "Create fail.";
            Console.WriteLine(message);
        }

        private void Update(int id, string blogTitle, string blogAuthor, string blogContent)
        {
            string message = string.Empty;
            var result = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (result is null)
            {
                message = "No Data Found.";
                goto Result;
            }
            result.Title = blogTitle;
            result.Author = blogAuthor;
            result.Content = blogContent;
            var save = db.SaveChanges();
            message = save > 0 ? "Update success" : "Update fail.";
        Result:
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            string message = string.Empty;
            var result = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (result is null)
            {
                message = "No Data Found.";
                goto Result;
            }
            db.Blogs.Remove(result);
            var remove = db.SaveChanges();
            message = remove > 0 ? "Delete success" : "Delete fail.";
        Result:
            Console.WriteLine(message);
        }

    }
}

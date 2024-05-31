using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZMMLDotNetCore.ConsoleApp.Model;
using ZMMLDotNetCore.ConsoleApp.Services;

namespace ZMMLDotNetCore.ConsoleApp.EFCoreExamples
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.connectionString.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}

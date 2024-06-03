﻿using Microsoft.EntityFrameworkCore;
using ZMMLDotNetCore.NLayer.DataAccess.Models;

namespace ZMMLDotNetCore.NLayer.DataAccess.Db;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<BlogModel> Blogs { get; set; }
}
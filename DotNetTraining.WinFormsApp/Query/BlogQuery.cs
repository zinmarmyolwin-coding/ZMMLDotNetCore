using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTraining.WinFormsApp.Query
{
    internal static class BlogQuery
    {
        public static string BlogCreate = @"INSERT INTO [dbo].[Tbl_Blog]
           ([Title],[Author],[Content])
            VALUES (@Title,@Author,@Content)";
    }
}

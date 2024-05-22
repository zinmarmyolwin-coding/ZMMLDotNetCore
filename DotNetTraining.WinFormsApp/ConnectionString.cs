using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTraining.WinFormsApp
{
    internal static class ConnectionString
    {
        public static SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-4QQ0V13\\SQLEXPRESS",
            InitialCatalog = "TestingDb",
            //UserID = "",
            //Password = "",
            //TrustServerCertificate = true,
        };
            
    }
}

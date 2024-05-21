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
            DataSource = "",
            InitialCatalog = "",
            UserID = "",
            Password = "",
            TrustServerCertificate = true,
        };
            
    }
}

using System.Data.SqlClient;

namespace ZMMLDotNetCore.NLayer.DataAccess;

internal static class ConnectionStrings
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "DotNetTraning",
        // InitialCatalog = "TestDb",
        UserID = "sa",
        Password = "sa@123",
        TrustServerCertificate = true
    };
}
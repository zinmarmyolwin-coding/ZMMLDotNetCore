
using Microsoft.Data.SqlClient;

namespace ZMMLDotNetCore.PizzaApi;

internal static class ConnectionStrings
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "DotNetTraning",
        UserID = "sa",
        Password = "sa@123",
        TrustServerCertificate = true,
    };
}
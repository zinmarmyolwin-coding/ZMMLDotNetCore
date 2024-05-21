using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using DotNetTraining.Shared.Model;

namespace DotNetTrainingBatch4.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<T> Query<T>(string query, params AdoDotNetParameterModel[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                var parametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            string json = JsonConvert.SerializeObject(dt);
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!; 

            return lst;
        }

        public T QueryFirstOrDefault<T>(string query, params AdoDotNetParameterModel[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                var parametersArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(parametersArray);
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            string json = JsonConvert.SerializeObject(dt); 
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!; 

            return lst[0];
        }

        public int Execute(string query, params AdoDotNetParameterModel[]? parameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (parameters is not null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
            }

            var result = cmd.ExecuteNonQuery();

            connection.Close();
            return result;
        }
    }

    public static class AdoDotNetParameterListExtension
    {
        public static List<AdoDotNetParameterModel> Add(this List<AdoDotNetParameterModel> lst, string name, object value)
        {
            lst.Add(new AdoDotNetParameterModel(name, value));
            return lst;
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.SqlClient;
using ZMMLDotNetCore.Shared.ConnectionService;
using ZMMLDotNetCore.Shared.Model;

namespace ZMMLDotNetCore.RestApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoDotNetController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlog()
        {
            string query = "select * from Tbl_Blog";
            var connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            List<BlogModel> lstBlog = new List<BlogModel>();
            //foreach (DataRow row in dt.Rows)
            //{
            //    BlogModel model = new BlogModel();
            //    model.BlogId = Convert.ToInt32(row["BlogId"]);
            //    model.Title = Convert.ToString(row["BlogId"]);
            //    model.Author = Convert.ToString(row["BlogId"]);
            //    model.Content = Convert.ToString(row["BlogId"]);
            //}
            lstBlog = dt.AsEnumerable().Select(dr => new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                Title = Convert.ToString(dr["Title"]),
                Author = Convert.ToString(dr["Author"]),
                Content = Convert.ToString(dr["Content"]),

            }).ToList();
            return Ok(lstBlog);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            string query = "select * from Tbl_Blog where BlogId = @BlogId";
            var connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            if (dt.Rows.Count == 0)
            {
                return NotFound("No data found");
            }
            var dr = dt.Rows[0];
            var item = new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogID"]),
                Title = Convert.ToString(dr["Title"]),
                Author = Convert.ToString(dr["Author"]),
                Content = Convert.ToString(dr["Content"]),
            };
            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel reqModel)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
            SET [Title] = @Title
              ,[Author] = @Author
              ,[Content] = @Content
             WHERE BlogId = @BlogId";
            var connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@Title", reqModel.Title);
            cmd.Parameters.AddWithValue("@Author", reqModel.Author);
            cmd.Parameters.AddWithValue("@Content", reqModel.Content);
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            return Ok(result > 0 ? "Update success" : "Update fail.");

        }

        [HttpPatch("{id}")]
        public IActionResult PatchUpdate(int id, BlogModel reqModel)
        {
            string condition = string.Empty;
            if (!reqModel.Title.IsNullOrEmpty())
            {
                condition += " [Title] = @Title, ";
            }
            if (!reqModel.Author.IsNullOrEmpty())
            {
                condition += " [Author] = @Author, ";
            }
            if (!reqModel.Content.IsNullOrEmpty())
            {
                condition += " [Content] = @Content, ";
            }
            if (condition.Length == 0)
            {
                return NotFound("No data found.");
            }
            condition = condition.Substring(0, condition.Length - 2);
            string query = $@"UPDATE [dbo].[Tbl_Blog]
            SET {condition}
             WHERE BlogId = @BlogId";
            var connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            if (!reqModel.Title.IsNullOrEmpty())
            {
                cmd.Parameters.AddWithValue("@Title", reqModel.Title);
            }
            if (!reqModel.Author.IsNullOrEmpty())
            {
                cmd.Parameters.AddWithValue("@Author", reqModel.Author);
            }
            if (!reqModel.Content.IsNullOrEmpty())
            {
                cmd.Parameters.AddWithValue("@Content", reqModel.Content);
            }
            var result = cmd.ExecuteNonQuery();

            connection.Close();
            return Ok(result > 0 ? "Patch Update success" : "Patch Update fail.");
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel reqModel)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([Title]
           ,[Author]
           ,[Content])
     VALUES
           (@Title
           ,@Author
           ,@Content)";
            var connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Title", reqModel.Title);
            cmd.Parameters.AddWithValue("@Author", reqModel.Author);
            cmd.Parameters.AddWithValue("@Content", reqModel.Content);
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            return Ok(result > 0 ? "Create success" : "Create fail.");


        }

        [HttpDelete("{id}")]
        public IActionResult BlogDelete(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                            WHERE BlogId = @BlogId";
            var connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            return Ok(result > 0 ? "Delete success" : "Delete fail.");
        }
    }
}

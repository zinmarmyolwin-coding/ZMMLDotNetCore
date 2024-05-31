using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ZMMLDotNetCore.Shared.Model;
using ZMMLDotNetCore.Shared.Services;

namespace ZMMLDotNetCore.RestApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoDotNetServiceController : ControllerBase
    {
        private readonly AdoDotNetService _service = new AdoDotNetService();

        [HttpGet]
        public IActionResult GetBlog()
        {
            string query = "select * from Tbl_BLog";
            var result = _service.Query<BlogModel>(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogById(int id)
        {
            string query = "select * from Tbl_BLog where BlogId = @BlogId";
            var result = _service.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameterModel("@BlogId", id));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel model)
        {
            string query = @"INSERT INTO [dbo].[Tbl_BLog]
           ([Title]
           ,[Author]
           ,[Content])
     VALUES
           (@Title
           ,@Author
           ,@Content)";
            var result = _service.Execute(query,
                new AdoDotNetParameterModel("@Title", model.Title),
                new AdoDotNetParameterModel("@Author", model.Author),
                new AdoDotNetParameterModel("@Content", model.Content));
            string message = result > 0 ? "Create Success." : "Create fail.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel model)
        {
            var item = GetById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            string query = @"UPDATE [dbo].[Tbl_BLog]
            SET [Title] = @Title
              ,[Author] = @Author
              ,[Content] = @Content
             WHERE BlogId = @BlogId";
            model.BlogId = id;
            var result = _service.Execute(query,
                new AdoDotNetParameterModel("@Title", model.Title!),
                new AdoDotNetParameterModel("@Author", model.Author!),
                new AdoDotNetParameterModel("@Content", model.Content!),
                new AdoDotNetParameterModel("@BlogId", model.BlogId));
            string message = result > 0 ? "Update Success." : "Update fail.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchUpdate(int id, BlogModel model)
        {
            var item = GetById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            string condition = string.Empty;
            if (!model.Title.IsNullOrEmpty())
            {
                condition += " [Title] = @Title, ";
            }
            if (!model.Author.IsNullOrEmpty())
            {
                condition += " [Author] = @Author, ";
            }
            if (!model.Content.IsNullOrEmpty())
            {
                condition += " [Content] = @Content, ";
            }
            if (condition.Length == 0)
            {
                return NotFound("No data found.");
            }
            condition = condition.Substring(0, condition.Length - 2);
            string query = $@"UPDATE [dbo].[Tbl_BLog]
            SET {condition}
             WHERE BlogId = @BlogId";
            model.BlogId = id;
            int result = 0;
            if (!model.Title.IsNullOrEmpty())
            {
                result = _service.Execute(query,
                new AdoDotNetParameterModel("@Title", model.Title!),
                new AdoDotNetParameterModel("@BlogId", model.BlogId!));
            }
            if (!model.Author.IsNullOrEmpty())
            {
                result = _service.Execute(query,
                new AdoDotNetParameterModel("@Author", model.Author!),
                new AdoDotNetParameterModel("@BlogId", model.BlogId!));
            }
            if (!model.Content.IsNullOrEmpty())
            {
                result = _service.Execute(query,
                new AdoDotNetParameterModel("@Content", model.Content!),
                new AdoDotNetParameterModel("@BlogId", model.BlogId!));
            }
            string message = result > 0 ? "PatchUpdate Success." : "PatchUpdate fail.";
            return Ok(message);
        }

        [HttpDelete]
        public IActionResult DeleteBlog(int id)
        {
            var item = GetById(id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            string query = @"DELETE FROM [dbo].[Tbl_BLog]
                            WHERE BlogId = @BlogId";
            var result = _service.Execute(query, new AdoDotNetParameterModel("@BlogId", id));
            string message = result > 0 ? "Delete Success." : "Delete fail.";
            return Ok(message);
        }

        private BlogModel GetById(int id)
        {
            string query = "select * from Tbl_BLog where BlogId = @BlogId";
            BlogModel? result = _service.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameterModel("@BlogId", id));
            if (result is null)
            {
                return null;
            }
            return result;
        }
    }
}

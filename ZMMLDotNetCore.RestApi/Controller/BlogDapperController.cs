using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ZMMLDotNetCore.Shared.Model;
using ZMMLDotNetCore.Shared.Services;

namespace ZMMLDotNetCore.RestApi.Controller
{
    [Route("api/blog")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {
        private readonly DapperService _dapperService = new DapperService();

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_Blog";
            var lst = _dapperService.Query<BlogModel>(query);
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogs(int id)
        {
            string query = "select * from Tbl_Blog where BlogId=@BlogId";
            var item = _dapperService.QueryFirstOrDefault<BlogModel>(query, new BlogModel { BlogId = id });
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel model)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([Title]
           ,[Author]
           ,[Content])
     VALUES
           (@Title
           ,@Author
           ,@Content)";
            var result = _dapperService.Execute(query, model);
            string message = result > 0 ? "Create success." : "Create fail.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel model)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            string query = @"UPDATE [dbo].[Tbl_Blog]
            SET [Title] = @Title
              ,[Author] = @Author
              ,[Content] = @Content
             WHERE BlogId = @BlogId";
            model.BlogId = id;
            var result = _dapperService.Execute(query, model);
            string message = result > 0 ? "Update successful" : "Update fail.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchUpdate(int id, BlogModel model)
        {
            var item = FindById(id);
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
            model.BlogId = id;
            string query = $@"UPDATE [dbo].[Tbl_Blog]
            SET {condition}
             WHERE BlogId = @BlogId";
            var result = _dapperService.Execute(query, model);
            string message = result > 0 ? "PatchUpdate successful" : "PatchUpdate fail.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found.");
            }
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                            WHERE BlogId = @BlogId";
            var result = _dapperService.Execute(query, new BlogModel { BlogId = id });
            string message = result > 0 ? "Delete Success." : "Delete fail.";
            return Ok(message);
        }

        private BlogModel? FindById(int id)
        {
            string query = "select * from Tbl_Blog where BlogId=@BlogId";
            var item = _dapperService.QueryFirstOrDefault<BlogModel>(query, new BlogModel { BlogId = id });
            return item;
        }
    }
}

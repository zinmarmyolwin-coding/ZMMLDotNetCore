using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NKKDotNetCore.RestApi.DbContexts;
using ZMMLDotNetCore.Shared.Model;

namespace ZMMLDotNetCore.RestApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogEFCoreController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public BlogEFCoreController()
        {
            _appDbContext = new AppDbContext();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lst = _appDbContext.Blogs.OrderByDescending(x => x.BlogId).ToList();
            if (lst.Count < 0)
            {
                return NotFound("No data found.");
            }
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _appDbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel reqModel)
        {
            string message = string.Empty;
            _appDbContext.Blogs.Add(reqModel);
            var result = _appDbContext.SaveChanges();
            message = result > 0 ? "Create success." : "Create fail.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel reqModel)
        {
            string message = string.Empty;
            var item = _appDbContext.Blogs.Find(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            item.Title = reqModel.Title;
            item.Author = reqModel.Author;
            item.Content = reqModel.Content;
            //_appDbContext.Update(item); // testing code
            var result = _appDbContext.SaveChanges();
            message = result > 0 ? "Update success." : "Update fail.";
            return Ok(message);

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel reqModel)
        {
            string message = string.Empty;
            var item = _appDbContext.Blogs.Find(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            if (!string.IsNullOrEmpty(reqModel.Title))
            {
                item.Title = reqModel.Title;
            }
            if (!string.IsNullOrEmpty(reqModel.Author))
            {
                item.Author = reqModel.Author;
            }
            if (!string.IsNullOrEmpty(reqModel.Content))
            {
                item.Content = reqModel.Content;
            }
            //_appDbContext.Update(item); // testing code
            var result = _appDbContext.SaveChanges();
            message = result > 0 ? "Update success." : "Update fail.";
            return Ok(message);
        }


        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            string message = string.Empty;
            var item = _appDbContext.Blogs.Find(id);
            if (item is null)
            {
                message = "Data not found";
            }
            _appDbContext.Remove(item!);
            var result = _appDbContext.SaveChanges();
            message = result > 0 ? "Create success." : "Create fail.";
            return Ok(message);
        }

    }
}

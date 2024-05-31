using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZMMLDotNetCore.RestApiWithNLayer.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnakesController : ControllerBase
    {
        private readonly BL_SnakesServices _service;
        public SnakesController(BL_SnakesServices service)
        {
            _service = service;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var model = await _service.GetAllData();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDataById(int id)
        {
            var model = await _service.GetAllData();
            return Ok(model!.FirstOrDefault(x => x.Id == id));
        }
    }
}

using ZMMLDotNetCore.RestApiWithNLayer.Model;

namespace ZMMLDotNetCore.RestApiWithNLayer.Features
{
    public class BL_SnakesServices
    {
        private readonly DA_SnakesServices _service;
        public BL_SnakesServices(DA_SnakesServices service)
        {
            _service = service;
        }

        public async Task<List<SnakeModel>?> GetAllData()
        {
            var lst = await _service.GetAllData();
            return lst;
        }
    }
}

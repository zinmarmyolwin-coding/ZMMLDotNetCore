using Newtonsoft.Json;
using ZMMLDotNetCore.RestApiWithNLayer.Model;

namespace ZMMLDotNetCore.RestApiWithNLayer.Features;

public class DA_SnakesServices
{
    public async Task<List<SnakeModel>?> GetAllData()
    {
        var jsonStr = await File.ReadAllTextAsync("data.json");
        var model = JsonConvert.DeserializeObject<List<SnakeModel>>(jsonStr);
        return model;
    }
}

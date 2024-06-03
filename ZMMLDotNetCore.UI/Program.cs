using ZMMLDotNetCore.NLayer.BusinessLogic.Services;
using ZMMLDotNetCore.NLayer.DataAccess.Models;
using Newtonsoft.Json;

BL_Blog bL_Blog = new BL_Blog();
var lst = bL_Blog.GetBlogs();
Console.WriteLine(lst);

List<BlogEntity> blogEntities = lst.Select(x =>
        new BlogEntity(x.BlogId, x.Title!, x.Author!, x.Content!))
    .ToList();

var jsonStr = JsonConvert.SerializeObject(lst, Formatting.Indented);
Console.WriteLine(jsonStr);
Console.WriteLine(blogEntities.ToString());
foreach (var blogEntity in blogEntities)
{
    Console.WriteLine(blogEntity);
}
foreach (var item in lst)
{
    Console.WriteLine(item);
}
Console.ReadLine();
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZMMLDotNetCore.NLayer.DataAccess.Models;

[Table("Tbl_Blog")]
public class BlogModel
{
    [Key]
    public int BlogId { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Content { get; set; }
}

public struct BlogStruct
{
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }
}

public record BlogEntity(int BlogId, string BlogTitle, string BlogAuthor, string BlogContent);

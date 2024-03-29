using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SP.Queries.Application.Entities;

[Table("Post")]
public class PostEntity
{
    [Key]
    public Guid PostId { get; set; }
    public string? Author { get; set; }
    public DateTime Dateposted { get; set; }
    public string? Message { get; set; }
    public int Likes { get; set; }
    public virtual IList<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
}
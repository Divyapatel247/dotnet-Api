using System;

namespace api.Dtos.Comment;

public class CommentDto
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public string CreatedBy { get; set; } = "";
    public int? StockId { get; set; }
}

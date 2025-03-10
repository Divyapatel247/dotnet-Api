using System;
using api.Dtos.Comment;

namespace api.Dtos.Stock;
 public class StockDto
{
    public int Id { get; set; }
    public string Symbol { get; set; } = "";
    public string CompanyName { get; set; } = "";
    public double Purchase { get; set; }
    public double Lastdev { get; set; }
    public string Industry { get; set; } = "";
    public long Marketcap { get; set; }

    public List<CommentDto>? Comments { get; set; }

}

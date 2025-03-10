

using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Comment;

public class CreateCommnetDto
{

  [Required]
  [MinLength(5, ErrorMessage = "Title must be 5 characters")]
  [MaxLength(280,ErrorMessage = "Title cannot be over 280 characters")]
  public string Title { get; set; } = "";

   [Required]
  [MinLength(5, ErrorMessage = "Comment must be 5 characters")]
  [MaxLength(280,ErrorMessage = "Comment cannot be over 280 characters")]
  public string Content { get; set; } = "";
}

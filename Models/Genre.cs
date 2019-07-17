using System.ComponentModel.DataAnnotations;

namespace bricks.Models
{
  public class Genre
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
  }
}
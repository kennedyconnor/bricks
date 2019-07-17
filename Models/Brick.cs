using System.ComponentModel.DataAnnotations;

namespace bricks.Models
{
  public class Brick
  {
    public int Id { get; set; }
    [Required]
    public string Shape { get; set; }

  }
}
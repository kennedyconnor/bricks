using System.ComponentModel.DataAnnotations;

namespace bricks.Models
{
  public class Set
  {
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }

    public string Info { get; set; }

    public int GenreId { get; set; }
  }
}
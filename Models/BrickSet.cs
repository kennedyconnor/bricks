using System.ComponentModel.DataAnnotations;

namespace bricks.Models
{
  public class BrickSet
  {
    public int Id { get; set; }
    [Required]
    public int BrickId { get; set; }


    [Required]
    public int SetId { get; set; }
  }
}
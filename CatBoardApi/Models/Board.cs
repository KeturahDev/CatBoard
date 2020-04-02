using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CatBoardApi.Models
{
  public class Board
  {
    public int BoardId { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    [Required]
    [StringLength(255)]
    public string Description { get; set; }
    public Board()
    {
      this.Posts = new HashSet<Post>();
    }
    public string BannerImage { get; set; }

    public virtual ICollection<Post> Posts { get; set; }
  }
    
}
using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace CatBoardApi.Models
{
    public class Comment
    {
      public int CommentId { get; set; }
      [Required]
      [StringLength(255)]
      public string Body { get; set; }
      // public int AuthorId { get; set; }
      public int UserId { get; set; }
      public int PostId { get; set; }
      public DateTime DateCreated { get; set; }
      public DateTime EditDate { get; set; }
      public int Score { get; set; }
    }
}

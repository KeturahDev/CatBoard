// using Microsoft.AspNetCore.Identity;
namespace CatBoardApi.Models
{
  public class User 
  // public class User : IdentityUser
  {
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password  { get; set; }
  }
}
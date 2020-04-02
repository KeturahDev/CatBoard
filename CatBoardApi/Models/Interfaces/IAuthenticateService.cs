namespace CatBoardApi.Models
{

  public interface IAuthenticateService
  {
      bool IsAuthenticated(TokenRequest request, out string token);
  }

}
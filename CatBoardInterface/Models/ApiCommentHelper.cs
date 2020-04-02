using System.Threading.Tasks;
using System;
using RestSharp;

namespace CatBoardInterface.Models
{
  public class ApiCommentHelper
  {

    public static async Task<string> GetCommentDetails(int boardId, int postId, int commentId)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"boards/{boardId}/posts/{postId}/comments", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }


    public static async Task CreateComment(int boardId, int postId, string newComment)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"boards/{boardId}/posts/{postId}/comments", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newComment);
      var response = await client.ExecuteTaskAsync(request);
    }


    public static async Task PutComment(int boardId, int postId, int commentId, string newComment)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"boards/{boardId}/posts/{postId}/comments/{commentId}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newComment);
      var response = await client.ExecuteTaskAsync(request);
    }


    public static async Task DeleteComment(int boardId, int postId, int commentId)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"boards/{boardId}/posts/{postId}/comments/{commentId}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task UpVote(int boardId, int postId)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"boards/{boardId}/posts/{postId}/upvote", Method.PATCH);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DownVote(int boardId, int postId)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"boards/{boardId}/posts/{postId}/downvote", Method.PATCH);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}
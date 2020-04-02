using System.Threading.Tasks;
using System;
using RestSharp;

namespace CatBoardInterface.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll(string controller)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"{controller}", Method.GET);
      var response = await client.ExecuteTaskAsync(request); //calls the api, gets a response with everything
      return response.Content; //gets the json body of the response
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"boards/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task<string> GetPost(int boardId, int postId)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"boards/{boardId}/posts/{postId}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string newBoard)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"boards", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newBoard);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task CreatePost(int boardId, string newPost)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"boards/{boardId}/posts", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPost);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(int id, string newBoard)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"boards/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newBoard);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task PutPost(int boardId, int postId, string newPost)
    {
      RestClient client = new RestClient("http://localhost:5000/api/");
      RestRequest request = new RestRequest($"boards/{boardId}/posts/{postId}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPost);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"boards/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task DeletePost(int boardId, int postId)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"boards/{boardId}/posts/{postId}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}
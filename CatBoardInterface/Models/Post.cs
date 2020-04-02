using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace CatBoardInterface.Models
{
  public class Post
  {
    public int PostId { get; set; }
    public int BoardId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int score { get; set; }

    // public ICollection<Comment> Comments { get; set; } for comments later on
    public static List<Post> GetPosts()
    {
      var apiCallTask = ApiHelper.GetAll("Posts");
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Post> postList = JsonConvert.DeserializeObject<List<Post>>(jsonResponse.ToString());
      return postList;
    }

    public static Post GetDetails(int boardId, int PostId)
    {
      var apiCallTask = ApiHelper.GetPost(boardId, PostId);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Post post = JsonConvert.DeserializeObject<Post>(jsonResponse.ToString());

      return post;
    }
    public static void CreatePost(int boardId, Post post)
    {
      string jsonPost = JsonConvert.SerializeObject(post);
      var apiCallTask = ApiHelper.CreatePost(boardId, jsonPost);
    }

    public static void PutPost(int boardId, Post post)
    {
      string jsonPost = JsonConvert.SerializeObject(post);
      var apiCallTask = ApiHelper.PutPost(boardId, post.PostId, jsonPost);
    }

    public static void DeletePost(int boardId, int postId)
    {
      var apiCallTask = ApiHelper.DeletePost(boardId, postId);
    }

    public static void UpVote(int boardId, int postId)
    {
      var apiCallTask = ApiHelper.UpVote(boardId, postId);
    }
    public static void DownVote(int boardId, int postId)
    {
      var apiCallTask = ApiHelper.DownVote(boardId, postId);
    }
  }
}
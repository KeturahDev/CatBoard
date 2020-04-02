using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace CatBoardInterface.Models
{
  public class Comment
  {
    public string Body { get; set; }
    public string DateCreated { get; set; }
    public int Score { get; set;  }
    public int PostId { get; set; }
    public int CommentId { get; set; }


    public static Comment GetCommentDetails(int boardId, int postId, int CommentId)
    {
      var apiCallTask = ApiCommentHelper.GetCommentDetails(boardId, postId, CommentId);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Comment comment = JsonConvert.DeserializeObject<Comment>(jsonResponse.ToString());

      return comment;
    }
    public static void CreateComment(int boardId, int postId, Comment comment)
    {
      string jsonComment = JsonConvert.SerializeObject(comment);
      var apiCallTask = ApiCommentHelper.CreateComment(boardId, postId, jsonComment);
    }

    public static void PutComment(int boardId, int postId, Comment comment)
    {
      string jsonComment = JsonConvert.SerializeObject(comment);
      var apiCallTask = ApiCommentHelper.PutComment(boardId, postId, comment.CommentId, jsonComment);
    }

    public static void DeleteComment(int boardId, int postId, int commentId)
    {
      var apiCallTask = ApiCommentHelper.DeleteComment(boardId, postId, commentId);
    }

    // public static void UpVote(int boardId, int postId, int commentId)
    // {
    //   var apiCallTask = ApiCommentHelper.UpVote(boardId, postId, commentId);
    // }
    // public static void DownVote(int boardId, int postId, int commentId)
    // {
    //   var apiCallTask = ApiCommentHelper.DownVote(postId, commentId);
    // }
  }
}
   
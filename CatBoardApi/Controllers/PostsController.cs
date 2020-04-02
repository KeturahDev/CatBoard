using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatBoardApi.Models;

using System.Globalization;

namespace CatBoardApi.Controllers
{
  [Route("api/boards/{boardId}/[controller]")]
  [ApiController]
  public class PostsController : ControllerBase
  {

    private CatBoardApiContext _db;

    public PostsController(CatBoardApiContext db)
    {
      _db = db;
    }

    // GET api/Posts
    [HttpGet]
    public ActionResult<IEnumerable<Post>> Get(int boardId)
    {
      List<Post> thesePosts = _db.Posts.Where(post => post.BoardId == boardId).ToList();
      return thesePosts;
    }

    // GET api/Posts/5
    [HttpGet("{id}")]
    public ActionResult<Post> Get(int boardId, int id)
    {
      Post thisPost = _db.Posts.FirstOrDefault(post => post.PostId == id);
      thisPost.Comments = _db.Comments.Where(comments => comments.PostId == id).ToList();
      return thisPost;
    }

    // POST api/Posts
    [HttpPost]
    public void Post(int boardId, [FromBody] Post post)
    {
      post.BoardId = boardId;
      post.DateCreated = DateTime.Now;
      post.EditDate = DateTime.Now;
      _db.Posts.Add(post);
      _db.SaveChanges();
    }

    // PUT api/Posts/5
    [HttpPut("{id}")]
    public void Put( int id, int boardId, [FromBody] Post post)
    {
      post.EditDate = DateTime.Now;
      post.PostId = id; //double checking id of the form body is the correct id
      post.BoardId = boardId;
      _db.Entry(post).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      Post thisPost = _db.Posts.FirstOrDefault(post => post.PostId == id);
      _db.Posts.Remove(thisPost);
      _db.SaveChanges();
    }

    //upvote
    [HttpPatch("{id}/upvote")]
    public void UpVote(int id)
    {
      Post thisPost = _db.Posts.FirstOrDefault(post => post.PostId == id);
      thisPost.Score ++;
      _db.Entry(thisPost).State = EntityState.Modified;
      _db.SaveChanges();
    }


    //downvote
    [HttpPatch("{id}/downvote")]
    public void DownVote(int id)
    {
      Post thisPost = _db.Posts.FirstOrDefault(post => post.PostId == id);
      thisPost.Score --;
      _db.Entry(thisPost).State = EntityState.Modified;
      _db.SaveChanges();
    }
  }
}
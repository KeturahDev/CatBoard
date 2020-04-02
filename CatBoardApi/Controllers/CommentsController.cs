using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatBoardApi.Models;

using System.Net;
using System.Net.Http;
// // using System.Web.Http.Filters;

namespace CatBoardApi.Controllers
{
  [Route("api/boards/{boardId}/posts/{postId}/[controller]")]
  [ApiController]
  public class CommentsController : ControllerBase
  {

    private CatBoardApiContext _db;

    public CommentsController(CatBoardApiContext db)
    {
      _db = db;
    }

    // GET api/Comments
    [HttpGet]
    public ActionResult<IEnumerable<Comment>> Get()
    {
      return _db.Comments.ToList();
    }

    // GET api/Comments/5
    [HttpGet("{id}")]
    public ActionResult<Comment> Get(int id)
    {
      Comment thisComment = _db.Comments.FirstOrDefault(comment => comment.CommentId == id);
      return thisComment;
    }

    // POST api/Comments
    [HttpPost]
    public void Post(int postId,[FromBody] Comment comment)
    {
        comment.DateCreated = DateTime.Now;
        comment.EditDate = DateTime.Now;
        comment.PostId = postId;
        _db.Comments.Add(comment);
        _db.SaveChanges();
    }

    // PUT api/Comments/5
    [HttpPut("{id}")]
    public void Put(int id, int postId, [FromBody] Comment comment)
    {
      comment.EditDate = DateTime.Now;
      comment.CommentId = id;
      comment.PostId = postId;
      _db.Entry(comment).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      Comment thisComment = _db.Comments.FirstOrDefault(comment => comment.CommentId == id);
      _db.Comments.Remove(thisComment);
      _db.SaveChanges();
    }
  }
}

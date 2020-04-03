using System.Reflection.PortableExecutable;
using CatBoardInterface.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CatBoardInterface.Controllers
{
  public class CommentsController : Controller
  {

    public ActionResult CommentDetails(int boardId, int postId, int commentId)
    {
      var thisComment = Comment.GetCommentDetails(boardId, postId, commentId);
      return View(thisComment);
    }


    public ActionResult Create(int boardId, int postId)
    {
      ViewBag.boardId = boardId;
      ViewBag.postId = postId;
      return View();
    }
    [HttpPost]
    public ActionResult Create(int boardId, int postId, Comment comment)
    {
      Comment.CreateComment(boardId, postId, comment);
      return RedirectToAction("Details", "Posts", new { boardId = boardId, postId = postId });
    }
    public ActionResult Edit(int boardId, int postId, int commentId)
    {
      ViewBag.BoardId = boardId;
      ViewBag.postId = postId;
      var thisComment = Comment.GetCommentDetails(boardId, postId, commentId);
      return View(thisComment);
    }

    [HttpPost]
    public ActionResult Edit(int boardId, int postId, Comment comment)
    {
      Comment.PutComment(boardId, postId, comment);
      return RedirectToAction("Details", "Posts", new { boardId = boardId, postId = postId });
    }

    public ActionResult Delete(int boardId, int postId, int commentId)
    {
      var thisComment = Comment.GetCommentDetails(boardId, postId, commentId);
      return View(thisComment);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int boardId, int postId, int commentId)
    {
      Comment.DeleteComment(boardId, postId, commentId);
    return RedirectToAction("Details", "Posts", new { boardId = boardId, postId = postId });
    }

  }
}
                              
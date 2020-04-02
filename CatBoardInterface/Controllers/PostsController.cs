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
  // [Route("/boards/{boardId}/posts/[controller]/")]
  // /boards/2/posts/details/1
  // ***/posts/1/
  public class PostsController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
    //<li>@Html.ActionLink($"{treat.Name}", "Details", new { boardId = treat.TreatId, psotId = 3 })</li>
    //<a href="/posts/details" name="boardId" value="@Model.BoardId">Link name here </a>

    // [HttpGet("/boards/{boardId}/posts/details/{postId}")]
    public ActionResult Details(int boardId, int postId)
    {
      var thisPost = Post.GetDetails(boardId, postId);
      return View(thisPost);
    }

    public ActionResult Create(int boardId)
    {
      ViewBag.boardId = boardId;
      return View();
    }

    [HttpPost]
    public ActionResult Create(int boardId, Post post)
    {
      Post.CreatePost(boardId, post);
      return RedirectToAction("Details", "Boards", new { id = boardId });
    }
    public ActionResult Edit(int boardId, int postId)
    {
      ViewBag.BoardId = boardId;
      var thisPost = Post.GetDetails(boardId, postId);
      return View(thisPost);
    }

    [HttpPost]
    public ActionResult Edit(int boardId, Post post)
    {
      Post.PutPost(boardId, post);
      return RedirectToAction("Details", "Boards", new { id = boardId });
    }

    public ActionResult Delete(int boardId, int postId)
    {
      var thisPost = Post.GetDetails(boardId, postId);
      return View(thisPost);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int boardId, int postId)
    {
      Post.DeletePost(boardId, postId);
      return RedirectToAction("Details", "Boards", new { id = boardId });
    }
  }
}
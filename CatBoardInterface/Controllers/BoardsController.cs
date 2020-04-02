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
  public class BoardsController : Controller
  {
    public IActionResult Index()
    {
      var allBoards = Board.GetBoards();
      return View(allBoards);
    }

    public ActionResult Details(int id)
    {
      var thisBoard = Board.GetDetails(id);
      var postsList = thisBoard.Posts.OrderByDescending(post => post.score);
      ViewBag.OrderedPosts = postsList;
      return View(thisBoard);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Board board)
    {
      Board.Post(board);
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      var thisBoard = Board.GetDetails(id);
      return View(thisBoard);
    }

    [HttpPost]
    public ActionResult Edit(Board board)
    {
      Board.Put(board);
      return RedirectToAction("Details", new { id = board.BoardId });
    }

    public ActionResult Delete(int id)
    {
      var thisBoard = Board.GetDetails(id);
      return View(thisBoard);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Board.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
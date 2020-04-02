using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatBoardApi.Models;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
namespace CatBoardApi.Controllers
{
  // [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class BoardsController : ControllerBase
  {

    private CatBoardApiContext _db;

    public BoardsController(CatBoardApiContext db)
    {
      _db = db;
    }

    // GET api/boards
    [HttpGet]
    public ActionResult<IEnumerable<Board>> Get()
    {
      return _db.Boards.ToList();
    }

    // GET api/boards/5
    [HttpGet("{id}")]
    public ActionResult<Board> Get(int id)
    {
      Board thisBoard = _db.Boards.FirstOrDefault(board => board.BoardId == id);
      thisBoard.Posts = _db.Posts.Where(posts => posts.BoardId == id).ToList(); //! adding display ability of /posts to the details functionality of board
      return thisBoard;
    }

    // POST api/boards
    [HttpPost]
    public void Post([FromBody] Board board)
    {
      _db.Boards.Add(board);
      _db.SaveChanges();
    }

    // PUT api/boards/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Board board)
    {
      board.BoardId = id;
      _db.Entry(board).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      Board thisBoard = _db.Boards.FirstOrDefault(board => board.BoardId == id);
      _db.Boards.Remove(thisBoard);
      _db.SaveChanges();
    }
  }
}

using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;


namespace CatBoardInterface.Models
{
  public class Board
  {
    public Board()
    {
      this.Posts = new HashSet<Post>();
    }
    public int BoardId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Post> Posts { get; set; }
    public static List<Board> GetBoards()
    {
      var apiCallTask = ApiHelper.GetAll("Boards");
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Board> boardList = JsonConvert.DeserializeObject<List<Board>>(jsonResponse.ToString());
      return boardList;
    }

    public static Board GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Board board = JsonConvert.DeserializeObject<Board>(jsonResponse.ToString());

      return board;
    }
    public static void Post(Board board)
    {
      string jsonBoard = JsonConvert.SerializeObject(board);
      var apiCallTask = ApiHelper.Post(jsonBoard);
    }

    public static void Put(Board board)
    {
      string jsonBoard = JsonConvert.SerializeObject(board);
      var apiCallTask = ApiHelper.Put(board.BoardId, jsonBoard);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}
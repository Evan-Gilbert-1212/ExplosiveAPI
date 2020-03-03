using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;

namespace ExplosiveAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]

  public class CheckInController : ControllerBase
  {
    [HttpPost("{userName}")]
    public ActionResult CheckUserIn(string userName)
    {
      var explosionDb = new DatabaseContext();

      var newCheckIn = new CheckIn()
      {
        Name = userName
      };

      explosionDb.CheckIns.Add(newCheckIn);
      explosionDb.SaveChanges();

      var updatedCheckIn = explosionDb.CheckIns.First(c => c.Name == userName);

      var jsonResult = JsonSerializer.Serialize(updatedCheckIn);

      var SaveResult = new ContentResult()
      {
        Content = jsonResult,
        ContentType = "application/json",
        StatusCode = 201
      };

      return SaveResult;
    }

    [HttpGet]
    public ActionResult ReturnCheckIns()
    {
      var explosionDb = new DatabaseContext();

      var json = JsonSerializer.Serialize(explosionDb.CheckIns);

      var QueryResult = new ContentResult()
      {
        Content = json,
        ContentType = "application/json",
        StatusCode = 200
      };

      return QueryResult;
    }
  }
}
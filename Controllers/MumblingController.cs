using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace ExplosiveAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]

  public class MumblingController : ControllerBase
  {
    [HttpGet("{mumbleInput}")]
    public string Mumble(string mumbleInput)
    {
      var output = "";

      for (var i = 0; i < mumbleInput.Length; i++)
      {
        if (output != "")
          output += "-";

        output += char.ToUpper(mumbleInput[i]) + new string(mumbleInput[i], i).ToLower();
      }

      var mumbleOutput = new Mumbling()
      {
        mumbleInput = mumbleInput,
        mumbleOutput = output
      };

      string json = JsonSerializer.Serialize(mumbleOutput);

      return json;
    }

  }
}
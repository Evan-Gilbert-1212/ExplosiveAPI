using System;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ExplosiveAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ExplosionController : ControllerBase
  {
    [HttpGet("{explodeInput}")]
    public string Explode(string explodeInput)
    {
      var output = "";

      for (var i = 0; i < explodeInput.Length; i++)
      {
        output += new string(explodeInput[i], Int32.Parse(explodeInput[i].ToString()));
      }

      var ExplosiveOutput = new Explosion()
      {
        explosionInput = explodeInput,
        explosionOutput = output
      };

      var json = JsonSerializer.Serialize(ExplosiveOutput);

      return json;
    }

  }
}
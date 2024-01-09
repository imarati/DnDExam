using BL.Services;
using Microsoft.AspNetCore.Mvc;
using Models.dtos;

namespace BL.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController
{
    [HttpPost]
    [Route("fight")]
    public JsonResult Fight([FromBody] OpponentsDto opponents)
    {
        IBattleService battleService = new BattleService(opponents.Player, opponents.Monster);
        var result = battleService.GetResult();
        return new JsonResult(result);
    }
}
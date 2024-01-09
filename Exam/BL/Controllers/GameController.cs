using BL.Services;
using Microsoft.AspNetCore.Mvc;
using Models.dtos;

namespace BL.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController
{
    private IBattleService _battleService;

    public GameController(IBattleService battleService) => _battleService = battleService;

    [HttpPost]
    [Route("fight")]
    public JsonResult Fight([FromBody] OpponentsDto opponents)
    {
        _battleService.SetOpponents(opponents.Player, opponents.Monster);
        var result = _battleService.GetResult();
        return new JsonResult(result);
    }
}
using Models.dtos;
using Models.interfaces;

namespace BL.Services;

public interface IBattleService
{
    public ResultDto GetResult();
    public void SetOpponents(ICreature player, ICreature monster);
}
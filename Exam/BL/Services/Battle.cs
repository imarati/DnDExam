using Models.dtos;
using Models.interfaces;
using Models.models;

namespace BL.Services;

public class Battle : IBattle
{
    private ICreature? Player { get; }
    private ICreature? Monster { get; }

    public Battle() {}
    
    public Battle(Player player, Monster monster)
    {
        Player = player;
        Monster = monster;
    }
    
    public ResultDto GetResult()
    {
        var result = new ResultDto { Logs = new List<Log>() };
        while (Player.HitPoints > 0 && Monster.HitPoints > 0)
        {
            if (Player.HitPoints > 0)
            {
                var log = ProcessRound(false);
                log.CharacterName = Player.Name;
                log.EnemyName = Monster.Name;
                result.Logs.Add(log);
            }

            if (Monster.HitPoints > 0)
            {
                var log = ProcessRound(true);
                log.CharacterName = Monster.Name;
                log.EnemyName = Player.Name;
                result.Logs.Add(log);
            }
        }

        result.Winner = Player.HitPoints > 0 ? Character.Player : Character.Monster;
        return result;
    }
    
    private Log ProcessRound(bool swap=false)
    {
        var active = Player;
        var passive = Monster;
        if (swap) (active, passive) = (passive, active);
        var log = new Log();
        var rnd = new Random();
        var throws = int.Parse(active.Damage.Split('d')[0]);
        var dice = int.Parse(active.Damage.Split('d')[1]);
        log.HitType = new HitType[active.AttackPerRound];
        log.Damage = new int[active.AttackPerRound];
        log.EnemyHp = new int[active.AttackPerRound];
        log.DiceRoll = new int[active.AttackPerRound];
        log.AttackModifier = active.AttackModifier;
        for (var i = 0; i < active.AttackPerRound && passive.HitPoints > 0; i++)
        {
            var hitRoll = rnd.Next(1, 21);
            log.DiceRoll[i] = hitRoll;
            log.EnemyHp[i] = passive.HitPoints;
            if (hitRoll == 1 || log.DiceRoll[i] + active.AttackModifier < passive.ArmorClass)
            {
                log.HitType[i] = HitType.Miss;
                continue;
            }

            if (hitRoll == 20)
            {
                log.HitType[i] = HitType.Critical;
                
                for (var _ = 0; _ < 2 * throws; _++)
                    log.Damage[i] += (rnd.Next(1, dice + 1));

                log.Damage[i] += active.DamageModifier;
                passive.HitPoints -= Math.Min(passive.HitPoints, log.Damage[i]);
                log.EnemyHp[i] = passive.HitPoints;
                if (passive.HitPoints == 0) break;
            }
                

            else
            {
                log.HitType[i] = HitType.Hit;
                
                for (var _ = 0; _ < throws; _++)
                    log.Damage[i] += (rnd.Next(1, dice + 1));
                log.Damage[i] += active.DamageModifier;
                passive.HitPoints -= Math.Min(passive.HitPoints, log.Damage[i]);
                log.EnemyHp[i] = passive.HitPoints;
                if (passive.HitPoints == 0) break;
            }
            
            
        }

        return log;
    }
}
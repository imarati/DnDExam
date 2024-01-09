using Models.dtos;
using Models.interfaces;
using Models.models;

namespace BL.Services;

public class BattleService : IBattleService
{
    private ICreature? Player { get; set; }
    private ICreature? Monster { get; set; }

    public BattleService() {}
    
    public BattleService(Player player, Monster monster)
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
            log.HitType[i] = AttackRoll(active.AttackModifier, passive.ArmorClass, hitRoll);
            
            if (log.HitType[i] == HitType.Miss)
            {
                continue;
            }
            
            log.Damage[i] = DamageRoll(dice, throws, active.AttackModifier, log.HitType[i]);
            passive.HitPoints -= Math.Min(passive.HitPoints, log.Damage[i]);
            log.EnemyHp[i] = passive.HitPoints;
            
            if (passive.HitPoints == 0) break;
        }

        return log;
    }

    private HitType AttackRoll(int AttackModifier, int ArmorClass, int hitRoll)
    {
        if (hitRoll == 1 || hitRoll + AttackModifier < ArmorClass)
        {
            return HitType.Miss;
        }

        else if (hitRoll == 20)
        {
            return HitType.Critical;
        }
        
        return HitType.Hit;
    }

    private int DamageRoll(int dice, int throws, int damageModifier, HitType hitType)
    {
        var rnd = new Random();
        int damage = 0;
        
        if (hitType == HitType.Critical)
        {
            throws *= 2;
        }

        for (var i = 0; i < throws; i++)
        {
            damage += (rnd.Next(1, dice + 1));
        }
        damage += damageModifier;

        return damage;
    }
}
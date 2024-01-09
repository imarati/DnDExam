using System.ComponentModel.DataAnnotations;
using Models.interfaces;

namespace Models.models;

public class Monster : ICreature
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    [Required]
    public int HitPoints { get; set; }
    [Required]
    public int AttackModifier { get; set; }
    [Required]
    public int AttackPerRound { get; set; }
    [Required]
    public string Damage { get; set; }
    [Required]
    public int DamageModifier { get; set; }
    [Required]
    public int ArmorClass { get; set; }
}
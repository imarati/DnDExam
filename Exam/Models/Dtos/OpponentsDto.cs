using Models.models;

namespace Models.dtos;

public class OpponentsDto
{
    public Player Player { get; }
    public Monster Monster { get; }

    public OpponentsDto(Player player, Monster monster)
    {
        Player = player;
        Monster = monster;
    }
}
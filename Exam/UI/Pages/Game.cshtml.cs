using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.dtos;
using Models.models;

namespace UI.Pages;

public class Game : PageModel
{
    private const string MonsterUrl = "https://localhost:7162/monster/getRandom";
    private const string GameUrl = "https://localhost:7162/game/fight";

    [BindProperty] public Player Player { get; set; } = new();
    public Monster Monster { get; set; }
    public ResultDto? Result;
    
    public void OnGet() { }

    public async Task OnPostAsync()
    {
        if (!ModelState.IsValid) return;
        using var client = new HttpClient();
        var monster = await client.GetFromJsonAsync<Monster>(MonsterUrl);
        Monster = monster;
        var result = await client.PostAsJsonAsync(GameUrl, new OpponentsDto(Player, monster!));
        Result = await result.Content.ReadFromJsonAsync<ResultDto>();
    }
}
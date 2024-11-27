using Naninovel;
using UnityEngine;

[CommandAlias("startMinigame")]
public class StartMinigameCommand : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var minigameService = Engine.GetService<MinigameService>();
        if (minigameService == null)
        {
            Debug.LogError("MinigameService is not registered or initialized.");
            return UniTask.CompletedTask;
        }

        minigameService.StartGame();
        return UniTask.CompletedTask;
    }
}
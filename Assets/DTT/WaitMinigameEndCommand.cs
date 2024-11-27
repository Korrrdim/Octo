using Naninovel;
using UnityEngine;

[CommandAlias("waitMinigameEnd")]
public class WaitMinigameEndCommand : Command
{
    public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var minigameService = Engine.GetService<MinigameService>();
        if (minigameService != null)
        {
            var tcs = new UniTaskCompletionSource();
            
            minigameService.OnGameEnd(() => tcs.TrySetResult());
            
            await tcs.Task;
            UnityEngine.Debug.Log("Minigame ended.");
        }
        else
        {
            UnityEngine.Debug.LogError("MinigameService is not registered or initialized.");
        }
    }
}

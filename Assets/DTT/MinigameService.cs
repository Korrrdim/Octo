using System;
using DTT.MinigameMemory;
using Naninovel;
using UnityEngine;

[InitializeAtRuntime]
public class MinigameService : IEngineService
{
    private MemoryGameManager _memoryGameManager;
    public UniTask InitializeServiceAsync()
    {
        // here should be minigame init, not searching. 
        _memoryGameManager = GameObject.FindObjectOfType<MemoryGameManager>();
        return UniTask.CompletedTask;
    }

    public void StartGame() => _memoryGameManager.StartGame();

    public void OnGameEnd(Action onGameFinish)
        => _memoryGameManager.Finish += (MemoryGameResults m) => onGameFinish?.Invoke();

    public void ResetService()
    {

    }

    public void DestroyService()
    {
    }
}

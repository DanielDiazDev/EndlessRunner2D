using System;
using System.Threading.Tasks;
using UnityEngine;

public class RestartCommand : ICommand
{
    public static event Action OnRestart;
    public Task Execute()
    {
        OnRestart?.Invoke();
        var gameFacade = ServiceLocator.Instance.GetService<GameFacade>();
        gameFacade.GameOver();
        gameFacade.LoadGameObjects();
        Time.timeScale = 1f;
        return Task.CompletedTask;
    }
}

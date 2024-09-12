using System.Threading.Tasks;
using UnityEngine;

public class PauseCommand : ICommand
{
    public Task Execute()
    {
        Time.timeScale = 0;
        return Task.CompletedTask;
    }
}

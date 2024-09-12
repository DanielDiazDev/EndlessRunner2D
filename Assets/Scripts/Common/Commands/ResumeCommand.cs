using System.Threading.Tasks;
using UnityEngine;

public class ResumeCommand : ICommand
{
    public Task Execute()
    {
        Time.timeScale = 1f;
        return Task.CompletedTask;
    }
}


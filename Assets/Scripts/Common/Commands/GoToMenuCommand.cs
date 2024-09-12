using System.Threading.Tasks;
using UnityEngine;

public class GoToMenuCommand : ICommand
{
    public async Task Execute()
    {
        Time.timeScale = 1f;
        await new LoadSceneCommand("MainMenu").Execute();
    }
}

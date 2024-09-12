using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
public class LoadSceneCommand : ICommand
{
    private string _sceneName;
    public LoadSceneCommand(string sceneName)
    {
        _sceneName = sceneName;
    }

    public async Task Execute()
    {
        await LoadScene(_sceneName);
        await Task.Delay(2000);
    }

    private async Task LoadScene(string loadScene)
    {
        var loadSceneAsync = SceneManager.LoadSceneAsync(loadScene);
        while(!loadSceneAsync.isDone)
        {
            await Task.Yield();
        }
        await Task.Yield();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    
    [SerializeField] private ScoreSystem _scoreSystem;
    [SerializeField] private GameFacade _gameFacade;
    private void Awake()
    {
        ServiceLocator.Instance.RegisterService(_scoreSystem);
        ServiceLocator.Instance.RegisterService(_gameFacade);
    }
    // Start is called before the first frame update
    void Start()
    {
        ServiceLocator.Instance.GetService<GameFacade>().LoadGameObjects();
    }
    private void OnDestroy()
    {
        ServiceLocator.Instance.UnregisterService<ScoreSystem>();
        ServiceLocator.Instance.UnregisterService<GameFacade>();
        ServiceLocator.Instance.UnregisterService<SoundSystem>();
    }
    

}

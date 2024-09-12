using UnityEngine;

public class StartRun : MonoBehaviour
{
    [SerializeField] private GameFacade _gameFacade;
    private bool _startButtonPressed;
    private void Update()
    {
        if (_startButtonPressed) 
        {
            _gameFacade.StartRun();
        }
    }
    public void StartButtonPressed(bool enable)
    {
        _startButtonPressed = enable;
        if (!enable)
        {
            Debug.Log("Run stopped, startButtonPressed = false");  
        }
    }

}

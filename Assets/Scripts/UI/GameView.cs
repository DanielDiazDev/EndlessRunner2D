using System;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private GameObject _pauseContent;
    [SerializeField] private Button _startButton;
    [SerializeField] private StartRun _startRun;
    private bool _isPaused;
    public static event Action OnStart;

    private void Start()
    {
        _startButton.onClick.AddListener(StartButtonPressed);
    }
    private void Update()
    {
        if (!_isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _isPaused = true;
                CommandQueue.Instance.AddCommand(new PauseCommand());
                _pauseContent.SetActive(true);
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                _isPaused = false;
                CommandQueue.Instance.AddCommand(new ResumeCommand());
                _pauseContent.SetActive(false);
            }
        }
    }
    public void PausedChange(bool enable)
    {
        _isPaused = enable;
    }
    public void Reset()
    {
        _startButton.gameObject.SetActive(true);
        

    }
    public void DontStartButtonPressed()
    {
        _startRun.StartButtonPressed(false);
    }
    private void StartButtonPressed()
    {
        _startButton.gameObject.SetActive(false);
        _startRun.StartButtonPressed(true);
        OnStart?.Invoke();
    }
}
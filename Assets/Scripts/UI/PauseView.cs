using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseView : MonoBehaviour
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _goToMenuButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _pauseView; 
    [SerializeField] private GameView _gameView;
    private void Start()
    {
        _resumeButton.onClick.AddListener(Resume);
        _goToMenuButton.onClick.AddListener(GoToMenu);
        _restartButton.onClick.AddListener(Restart);
    }
    private void Restart()
    {
        _gameView.PausedChange(false);
        _pauseView.SetActive(false);
        CommandQueue.Instance.AddCommand(new RestartCommand());
    }

    private void GoToMenu()
    {
        CommandQueue.Instance.AddCommand(new GoToMenuCommand());
    }

    private void Resume()
    {
        _gameView.PausedChange(false);
        _pauseView.SetActive(false);
        CommandQueue.Instance.AddCommand(new ResumeCommand());
    }
}

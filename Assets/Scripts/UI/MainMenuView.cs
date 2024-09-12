using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    [SerializeField] private GameObject _mainMenuButtons;
    [SerializeField] private TextMeshProUGUI _maxScoreText;
    // Start is called before the first frame update
    void Start()
    {
        var maxScore = PlayerPrefs.GetFloat("MaxScore");
        _maxScoreText.text = maxScore.ToString();
        _startGame.onClick.AddListener(StartGame);
    }
    private async void StartGame()
    {
        await new LoadSceneCommand("Game").Execute();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _finalScoreText;
    [SerializeField] private TextMeshProUGUI _maxScoreText;
    private void Start()
    {
        ScoreSystem.OnScoreUpdate += ShowScore;
        ScoreSystem.OnScoreUpdate += ShowFinalScore;
        ScoreSystem.OnMaxScore += ShowMaxScore;
    }
    private void OnDestroy()
    {
        ScoreSystem.OnScoreUpdate -= ShowScore;
        ScoreSystem.OnScoreUpdate -= ShowFinalScore;
        ScoreSystem.OnMaxScore -= ShowMaxScore;
    }

    public void ShowScore(float score)
    {
        _scoreText.text = score.ToString();
    }
    public void ShowFinalScore(float score)
    {
        _finalScoreText.text = score.ToString();
    }
    public void ShowMaxScore(float maxScore)
    {
        _maxScoreText.text = maxScore.ToString();
    }
}

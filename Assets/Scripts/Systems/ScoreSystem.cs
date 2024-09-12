using System;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private float _incrementAtScore = 0f;
    private float _score;
    private float _maxScore;
    private const float SpeedThreshold = 10f;
    public static event Action<float> OnScoreUpdate;
    public static event Action<float> OnMaxScore;
    public static event Action OnSpeedSpawnObstacle;

    public void UpdateScore(float score)
    {
        _score = score;
        if (_score >= _incrementAtScore + SpeedThreshold)
        {
            OnSpeedSpawnObstacle?.Invoke();
            _incrementAtScore += SpeedThreshold;
        }
        OnScoreUpdate?.Invoke(_score);
    }
    public void Reset()
    {
        _score = 0f;
    }

    public void SetMaxScore()
    {
        if(_score > _maxScore)
        {
            _maxScore = _score;
        }
        PlayerPrefs.SetFloat("MaxScore", _maxScore);
        OnMaxScore?.Invoke(_maxScore);
    }
}

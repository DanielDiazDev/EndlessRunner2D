using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{

    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private GameOverView _gameOverView;
    [SerializeField] private Player _player;
    public void LoadGameObjects()
    {
        _gameOverView.DeactivateGameOverPanel();
        ServiceLocator.Instance.GetService<ScoreSystem>().Reset();
    }
    public void StartRun()
    {
        _obstacleSpawner.StartSpawn();
    }
    public void UpdateScore(float score)
    {
        ServiceLocator.Instance.GetService<ScoreSystem>().UpdateScore(score);
    }
    public void GameOver()
    {
        _obstacleSpawner.StopSpawn();
        _obstacleSpawner.DestroyAllObstacles();
        ServiceLocator.Instance.GetService<ScoreSystem>().SetMaxScore();
        _gameOverView.ActiveGameOverPanel();
    }
}

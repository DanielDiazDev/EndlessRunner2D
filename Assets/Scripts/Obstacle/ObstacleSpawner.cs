using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] private List<Obstacle> _obstacles;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _obstacleContainer;
    [SerializeField] private float _spawnRate;
    private float _nextSpawnTime = 0f;
    private bool _isSpawning;
    private List<GameObject> _activeObstacles = new List<GameObject>();
    
    private void Update()
    {
        if (_isSpawning)
        {
            if (Time.time > _nextSpawnTime)
            {
                Spawn();
                _nextSpawnTime = Time.time + _spawnRate;
            }
        }
    }
    public void StartSpawn()
    {
        _isSpawning = true;
    }
    public void StopSpawn()
    {
        _isSpawning = false;
        Debug.Log("Spawn parado");
    }
    private void Spawn()
    {
        var obstacle = _obstacles[UnityEngine.Random.Range(0, _obstacles.Count)];
        var obstacleInstantiated = Instantiate(obstacle, _spawnPoint.position, Quaternion.identity, _obstacleContainer);
        _activeObstacles.Add(obstacleInstantiated.gameObject);
    }
    public void DestroyAllObstacles()
    {
        foreach (var obstacle in _activeObstacles)
        {
            if (obstacle != null)
            {
                Destroy(obstacle);
            }
        }
        _activeObstacles.Clear(); 
    }
}

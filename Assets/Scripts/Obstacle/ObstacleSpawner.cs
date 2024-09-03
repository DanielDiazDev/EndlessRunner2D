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
    private void Update()
    {
        if (Time.time > _nextSpawnTime)
        {
            Spawn();
            _nextSpawnTime = Time.time + _spawnRate;
        }
    }

    private void Spawn()
    {
        var obstacle = _obstacles[UnityEngine.Random.Range(0, _obstacles.Count)];
        Instantiate(obstacle, _spawnPoint.position, Quaternion.identity, _obstacleContainer);
    }
}

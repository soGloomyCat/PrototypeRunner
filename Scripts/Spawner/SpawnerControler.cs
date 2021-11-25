using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControler : ObjectPool
{
    [SerializeField] private GameObject[] _enemyPool;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private Transform[] _spawns;

    private float _elapseTime;

    private void Start()
    {
        _elapseTime = 0;
        Initialize(_enemyPool);
    }

    private void Update()
    {
        _elapseTime += Time.deltaTime;

        if (_elapseTime >= _timeBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                int spawnPointNumber;

                _elapseTime = 0;
                spawnPointNumber = Random.Range(0, _spawns.Length);
                SetEnemy(enemy, _spawns[spawnPointNumber].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}

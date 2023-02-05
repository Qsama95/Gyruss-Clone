using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] 
    private EnemySpawnController _enemySpawnController;
    [SerializeField]
    [Range(1, 5)] private float _enemySpawnDelay;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _enemySpawnController.InitializeDictionary();

        InvokeRepeating(nameof(SpawnEnemy), 1, _enemySpawnDelay);
    }

    private void SpawnEnemy()
    {
        // spawn only enemy_01 type for this project
        _enemySpawnController.SpawnEnemyAtPosition("enemy_01", Vector2.zero);
    }
}

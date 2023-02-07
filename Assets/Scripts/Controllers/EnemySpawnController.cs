using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "EnemySpawnController", menuName = "Controllers/EnemySpawnController")]
public class EnemySpawnController : ScriptableObject
{
    [Serializable]
    public class EnemyIDPrefabPair
    {
        public string ID;
        public GameObject EnemeyPrefab;
    }

    [SerializeField]
    private List<EnemyIDPrefabPair> _enemyIdPrefabPairs 
        = new List<EnemyIDPrefabPair>();

    private Dictionary<string, GameObject> _enemyIdPrefabDictionary
        = new Dictionary<string, GameObject>();

    public void InitializeDictionary()
    {
        foreach (EnemyIDPrefabPair pair in _enemyIdPrefabPairs)
        {
            _enemyIdPrefabDictionary.Add(pair.ID, pair.EnemeyPrefab);
        }
    }

    /// <summary>
    /// spawn enemy at pos with id
    /// </summary>
    /// <param name="enemyId"></param>
    /// <param name="pos"></param>
    public void SpawnEnemyAtPosition(string enemyId, Vector3 pos)
    {
        if (_enemyIdPrefabDictionary.ContainsKey(enemyId))
        {
            var enemyToSpawn = Instantiate(
                _enemyIdPrefabDictionary[enemyId], 
                pos,
                Quaternion.identity);
        }
    }
}

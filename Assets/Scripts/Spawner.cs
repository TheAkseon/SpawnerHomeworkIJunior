using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private float _spawnInterval = 2.0f;
    private int _currentSpawnPointIndex = 0;
    private SpawnPoint[] _spawnPoints;
    private bool _isNeedSpawn = true;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (_isNeedSpawn)
        {
            Instantiate(_enemyPrefab.gameObject, _spawnPoints[_currentSpawnPointIndex].gameObject.transform.position, Quaternion.identity);
            Debug.Log("Spawn");
            _currentSpawnPointIndex++;

            if (_currentSpawnPointIndex >= _spawnPoints.Length)
            {
                _currentSpawnPointIndex = 0;
            }

            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}

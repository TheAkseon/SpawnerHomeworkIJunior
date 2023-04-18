using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;

    private float _spawnInterval = 2.0f;
    private int _currentSpawnPointIndex = 0;
    private SpawnPoint[] _spawnPoints;
    private bool _isNeedSpawn = true;
    private WaitForSecondsRealtime _wait;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        _wait = new WaitForSecondsRealtime(_spawnInterval);
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (_isNeedSpawn)
        {
            Instantiate(_prefab.gameObject, _spawnPoints[_currentSpawnPointIndex].gameObject.transform.position, Quaternion.identity);

            _currentSpawnPointIndex++;

            if (_currentSpawnPointIndex >= _spawnPoints.Length)
            {
                _currentSpawnPointIndex = 0;
            }

            yield return _wait;
        }
    }
}

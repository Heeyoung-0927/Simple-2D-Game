using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private int _enemyCount = 5;

    // References to spawn locations around the map
    [SerializeField]
    private Transform _spawnTopLeft, _spawnTopRight, _spawnBottomLeft, _spawnBottomRight;

    void Start()
    {
        // Initialize the game by spawning a set number(5) of enemies
        for (int i = 0; i < _enemyCount; i++)
        {
            SpawnEnemy(); 
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = SelectRandomPosition();

        // Create the enemy instance
        GameObject enemyObject = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();

        // When this specific enemy dies, 'SpawnEnemy' is called again, creating an endless loop of enemies
        if (enemy != null)
        {
            enemy.OnDie += SpawnEnemy;
        }
    }

    private Vector3 SelectRandomPosition()
    {
        Transform selectedTransform = null;

        // Pick a random number between 0 and 3
        int randomValue = Random.Range(0, 4);

        // Convert the random number into a SpawnPointType enum
        SpawnPointType spawnType = (SpawnPointType)randomValue;

        // Select the transform based on the random enum
        switch (spawnType)
        {
            case SpawnPointType.TopLeft:
                selectedTransform = _spawnTopLeft;
                break;
            case SpawnPointType.TopRight:
                selectedTransform = _spawnTopRight;
                break;
            case SpawnPointType.BottomLeft:
                selectedTransform = _spawnBottomLeft;
                break;
            case SpawnPointType.BottomRight:
                selectedTransform = _spawnBottomRight;
                break;
            default:
                selectedTransform = _spawnTopLeft;
                break;
        }

        // Add a random point inside a circle of radius 1 to the spawn position
        // This prevents enemies from spawning on the exact same pixel
        return selectedTransform.position + (Vector3)Random.insideUnitCircle;
    }

    void Update()
    {
        
    }
}

// Enum to make spawn point selection more readable
public enum SpawnPointType
{
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight
}
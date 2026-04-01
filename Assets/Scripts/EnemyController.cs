using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int maxEnemies = 10;
    public float spawnInterval = 3f;

    private List<GameObject> activeEnemies = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("CheckAndSpawn", 1f, spawnInterval);
    }

    void CheckAndSpawn()
    {
        activeEnemies.RemoveAll(e => e == null);

        if (activeEnemies.Count < maxEnemies)
        {
            Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject newEnemy = Instantiate(enemyPrefab, point.position, point.rotation);
            activeEnemies.Add(newEnemy);
        }

    }

}

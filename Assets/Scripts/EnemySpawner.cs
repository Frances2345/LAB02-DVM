using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 10;
    public float spawnInterval = 3f;
    public float spawnRange = 15f;
    public int quantityPerBatch = 2;

    private List<GameObject> activeEnemies = new List<GameObject>();
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && activeEnemies.Count < maxEnemies)
        {
            SpawnBatch();
            timer = 0f;
        }
        activeEnemies.RemoveAll(enemy => enemy == null);
    }

    void SpawnBatch()
    {
        for (int i = 0; i < quantityPerBatch; i++)
        {
            if (activeEnemies.Count >= maxEnemies) break;
            {
                Vector3 randomPoint = transform.position + Random.insideUnitSphere * spawnRange;
                randomPoint.y = transform.position.y;

                GameObject newEnemy = Instantiate(enemyPrefab, randomPoint, Quaternion.identity);
                activeEnemies.Add(newEnemy);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }
}

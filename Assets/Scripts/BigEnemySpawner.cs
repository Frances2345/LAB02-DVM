using UnityEngine;
using System.Collections.Generic;

public class BigEnemySpawner : MonoBehaviour
{
    public GameObject bigEnemyPrefab;
    public int maxBigEnemies = 1;
    public float spawnInterval = 5f;
    public float spawnRange = 10f;
    public int quantityPerBatch = 1;

    private List<GameObject> activeBigEnemies = new List<GameObject>();
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && activeBigEnemies.Count < maxBigEnemies)
        {
            SpawnBigEnemy();
            timer = 0f;
        }
        activeBigEnemies.RemoveAll(enemy => enemy == null);
    }

    public void SpawnBigEnemy()
    {
        for (int i = 0; i < quantityPerBatch; i++)
        {
            if (activeBigEnemies.Count >= maxBigEnemies)
            {
                break;
            }

            Vector3 randomPoint = transform.position + Random.insideUnitSphere * spawnRange;
            randomPoint.y = transform.position.y;

            GameObject newBigEnemy = Instantiate(bigEnemyPrefab, randomPoint, Quaternion.identity);
            activeBigEnemies.Add(newBigEnemy);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }

}

using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class BigEnemySpawner : MonoBehaviour
{
    public GameObject bigEnemyPrefab;
    public int maxBigEnemies = 1;
    public float spawnInterval = 5f;
    public float spawnRange = 10f;

    private List<GameObject> activeBigEnemies = new List<GameObject>();
    private float timer;

    void Update()
    {
        activeBigEnemies.RemoveAll(enemy => enemy == null);

        timer += Time.deltaTime;

        if (timer >= spawnInterval && activeBigEnemies.Count < maxBigEnemies)
        {
            SpawnBigEnemy();
            timer = 0f;
        }
    }

    public void SpawnBigEnemy()
    {
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * spawnRange;
        randomPoint.y = transform.position.y;

        GameObject newBigEnemy = Instantiate(bigEnemyPrefab, randomPoint, Quaternion.identity);
        activeBigEnemies.Add(newBigEnemy);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }

}

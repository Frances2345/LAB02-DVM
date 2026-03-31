using UnityEngine;
using UnityEngine.AI;

public class EnemyRandomizer : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("no hay obejto con el tag Player");
        }

        agent.speed = Random.Range(3.0f, 6.0f);
        agent.acceleration = Random.Range(7.0f, 15.0f);
        agent.angularSpeed = Random.Range(120f, 250f);
        agent.stoppingDistance = Random.Range(1.2f, 2.5f);
        agent.avoidancePriority = Random.Range(0, 99);

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && agent.isOnNavMesh)
        {
            agent.SetDestination(player.position);
        }
    }
}

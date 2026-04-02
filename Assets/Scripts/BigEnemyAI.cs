using UnityEngine;
using UnityEngine.AI;

public class BigEnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            target = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && agent.enabled && agent.isOnNavMesh)
        {
            agent.SetDestination(target.position);
        }
    }
}

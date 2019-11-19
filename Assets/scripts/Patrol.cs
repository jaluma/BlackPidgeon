using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour
{

    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();       
        agent.autoBraking = false;
        agent.SetDestination(RandomNavmeshLocation(50f));        

    }

    void Update()
    {
       
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        agent.SetDestination(RandomNavmeshLocation(50f));
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
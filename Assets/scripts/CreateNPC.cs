using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class CreateNPC : MonoBehaviour
{

    public NavMeshAgent agent;
    public NavMeshAgent agent1;
    public NavMeshAgent agent2;
    public NavMeshAgent agent3;
    public NavMeshAgent agent4;
    public NavMeshAgent agent5;
    public NavMeshAgent agent6;

    private int npcCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateNPC());
    }

    // Update is called once per frame
    IEnumerator GenerateNPC()
    {
        while (npcCount < 10)
        {
            Instantiate(agent, RandomNavmeshLocation(50), Quaternion.identity);
            Instantiate(agent1, RandomNavmeshLocation(50), Quaternion.identity);
            Instantiate(agent2, RandomNavmeshLocation(50), Quaternion.identity);
            Instantiate(agent3, RandomNavmeshLocation(50), Quaternion.identity);
            Instantiate(agent4, RandomNavmeshLocation(50), Quaternion.identity);
            Instantiate(agent5, RandomNavmeshLocation(50), Quaternion.identity);
            Instantiate(agent6, RandomNavmeshLocation(50), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            npcCount++;
        }
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

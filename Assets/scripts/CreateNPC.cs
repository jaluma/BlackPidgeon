using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class CreateNPC : MonoBehaviour
{

    public GameObject agent;
    private int npcCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateNPC());
        Application.targetFrameRate = 60;
    }

    IEnumerator GenerateNPC()
    {
        while (ObjectPooler.SharedInstance.pooledObjects.Count < 29)
        {
            agent = ObjectPooler.SharedInstance.GetPooledObject();

            if (agent != null)
            {
                agent.transform.rotation = Quaternion.identity;
                agent.transform.position = RandomNavmeshLocation(50);
                agent.SetActive(true);
            }

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

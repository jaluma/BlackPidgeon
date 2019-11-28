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
        while (npcCount < 200)
        {
            if (ObjectPooler.SharedInstance != null)
            {
                agent = ObjectPooler.SharedInstance.GetPooledObject();

                if (agent != null)
                {
                    agent.transform.rotation = Quaternion.identity;
                    agent.transform.position = RandomNavmeshLocation(200);
                    agent.transform.parent = GameObject.FindGameObjectWithTag("CloneNPC").transform;
                    agent.SetActive(true);
                }

                yield return new WaitForSeconds(0.1f);
                npcCount++;
            }
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

using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class CreateNPC : MonoBehaviour
{

    public GameObject agent;
    private int npcCount;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateNPC());
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    IEnumerator GenerateNPC()
    {
        while (npcCount < 30)
        {
            agent = ObjectPooler.SharedInstance.GetPooledObject();           
            for (int i = 0; i < 7; i++)
            {
                if (agent != null)
                {
                    agent.transform.position = RandomNavmeshLocation(50);
                    agent.transform.rotation = Quaternion.identity;
                    agent.SetActive(true);
                }
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

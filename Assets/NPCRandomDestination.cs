using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRandomDestination : MonoBehaviour
{
    public int genPos;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC") {

            genPos = Random.Range(1, 8);

            if (genPos == 7)
            {
                this.gameObject.transform.position = new Vector3(189, 1, 248);
            }

            if (genPos == 6)
            {
                this.gameObject.transform.position = new Vector3(159, 1, 164);
            }

            if (genPos == 5)
            {
                this.gameObject.transform.position = new Vector3(113, 1, 118);
            }

            if (genPos == 4)
            {
                this.gameObject.transform.position = new Vector3(113, 1, 226);
            }
            if (genPos == 3)
            {
                this.gameObject.transform.position = new Vector3(113, 1, 283);
            }
            if (genPos == 2)
            {
                this.gameObject.transform.position = new Vector3(95, 1, 304);
            }
            if (genPos == 1)
            {
                this.gameObject.transform.position = new Vector3(75, 1, 304);
            }
        }
    }

   
}

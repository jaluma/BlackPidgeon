using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatarFarola : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PigeonBullet"))
        {
            gameObject.SetActive(false);
        }
    }
    
}

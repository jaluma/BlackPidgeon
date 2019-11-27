using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName = "TownHallScene";

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Palomo"))
        {
            SceneManager.LoadScene("TownHallScene");
        }
    }

    

}

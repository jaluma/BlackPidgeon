using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MayorCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("poop") || collision.gameObject.tag.Contains("PigeonBullet"))
        {
            SceneManager.LoadScene("Credits");
        }
    }
}

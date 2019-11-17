using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraWalk : MonoBehaviour {

    public int speed = 2;

	// Use this for initialization
	void Start () {

  //      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Camera>();		
	}
	
	// Update is called once per frame
	void Update () {

        if (Camera.main != null)
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        else
            Debug.Log("Couldnt find tag MainCamera");
	}

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("TrophyTag"))
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}

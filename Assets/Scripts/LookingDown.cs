using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingDown : MonoBehaviour
{
    private bool menuOut;
    GameObject[] menuElemets;
    public int timeOutofMenu = 0;
    GameObject c;
    public float distance;
    public float altura;
    public float YRotationCamera;
    public float YRotationCanvas;

    // Start is called before the first frame update
    void Start()
    {
        menuElemets = GameObject.FindGameObjectsWithTag("MenuElements");
        c = GameObject.FindGameObjectWithTag("Canvas");

        HideMenu();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timeOutofMenu);
       //Debug.Log("x:" + gameObject.transform.eulerAngles.x);
        Debug.Log("y:" + gameObject.transform.eulerAngles.y);
        //Debug.Log("z:" + gameObject.transform.eulerAngles.z);
        // Debug.Log(gameObject.transform.rotation.ToString());
        

        if (Vector3.Dot(gameObject.transform.forward, Vector3.down) > 0.766f)
        {
            if (!menuOut)
            {
                ShowMenu();

            }
            Debug.Log("I'm looking down!");
          
        }
        else
        {
            if (Vector3.Dot(gameObject.transform.forward, Vector3.down) > 0.166f)
            {
                timeOutofMenu = 0;
            }
            if(timeOutofMenu >= 300)
            {
                HideMenu();
                Debug.Log("han pasado 5 segs");
                timeOutofMenu = 0;
            }
            else
            {
                timeOutofMenu++;
                
            }
            
        }
    }

    private void ShowMenu()
    {
        //var rotationY = transform.rotation.y;

       /* if (Mathf.Abs(transform.forward.x) > 0 || Mathf.Abs(transform.forward.z) > 0)
        {
           if(transform.forward.x > 0 || transform.forward.z > 0)
            {
                rotationY += 90;
            }
            else
            {
                rotationY -= 90;
            }
        }*/
        var a = new Vector3(transform.forward.x, transform.forward.y + altura, transform.forward.z);
        c.transform.position = transform.position + a * distance;

        YRotationCamera = transform.rotation.y;



        /*if(transform.rotation.y >= 90 && transform.eulerAngles.y <= 270)
         {
             angleY += 180;
         }*/
        c.transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z));
        YRotationCanvas = c.transform.rotation.y;
        foreach (GameObject o in menuElemets)
        {
            menuOut = true;
            Time.timeScale = 0.3f;
            o.SetActive(true);

        }
       

    }

    private void HideMenu()
    {
        foreach (GameObject o in menuElemets)
        {
            menuOut = false;
            Time.timeScale = 1.0f;
            o.SetActive(false);
        }
    }
}

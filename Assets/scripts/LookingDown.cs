using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LookingDown : MonoBehaviour
{
    private bool menuOut;
    GameObject[] menuElemets;
    public int TimeOutofMenu = 0;
    public int TimeLimit = 300;
    public float ToleranciaMirarSuelo = 0.766f;
    public float Ralentizacion = 0.3f;
    GameObject c;
    GameObject copyCanvas;
    public float Distance = 0.7f;
    public float Altura = 1.1F;
    public float YRotationCamera;
    public float YRotationCanvas;
    public long SecondDelay = 2;

    private DateTime lastShow;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        menuElemets = GameObject.FindGameObjectsWithTag("MenuElements");
        copyCanvas = GameObject.FindGameObjectWithTag("Canvas");
        c = copyCanvas;

        player = GameObject.FindGameObjectWithTag("Player");

        HideMenu();
        UpdateLastShowed();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(TimeOutofMenu);
       //Debug.Log("x:" + gameObject.transform.eulerAngles.x);
       // Debug.Log("y:" + gameObject.transform.eulerAngles.y);
        //Debug.Log("z:" + gameObject.transform.eulerAngles.z);
        // Debug.Log(gameObject.transform.rotation.ToString());
        

        if (Vector3.Dot(gameObject.transform.forward, Vector3.down) > ToleranciaMirarSuelo)
        {
            if (!menuOut) {
                var now = GetTime(DateTime.Now);
                var lastUpdate = GetTime(lastShow);
                //if (lastUpdate + SecondDelay * 1000 >= now) {
                    ShowMenu();
                    UpdateLastShowed();
                //}
            }
            Debug.Log("I'm looking down!");
          
        }
        else
        {
            if (Vector3.Dot(gameObject.transform.forward, Vector3.down) > 0.166f) {
                TimeOutofMenu = 0;
            }
            if (TimeOutofMenu >= TimeLimit) {
                HideMenu();
                Debug.Log("han pasado 5 segs");
                TimeOutofMenu = 0;
            } else {
                TimeOutofMenu++;

            }

        }
    }

    private void ShowMenu()
    {

        c = copyCanvas;
         var a = new Vector3(transform.forward.x, transform.forward.y + Altura, transform.forward.z);
         c.transform.position = transform.position + a * Distance;


        //c.transform.Rotate(new Vector3(transform.rotation.x, transform.eulerAngles.y, transform.rotation.z));

        // lo sigueinte arregla la rotacion andando...
        var rotation = Quaternion.LookRotation(transform.position);
        rotation *= Quaternion.Euler(0, transform.rotation.y, 0);
        c.transform.rotation = Quaternion.Slerp(c.transform.rotation, rotation, Time.deltaTime);

        YRotationCamera = transform.rotation.y;
        YRotationCanvas = c.transform.rotation.y;

        /* Vector3 playerPosition = new Vector3(transform.position.x,c.transform.position.y,transform.position.z);
         c.transform.LookAt(playerPosition);*/


        foreach (GameObject o in menuElemets)
        {
            menuOut = true;
            Time.timeScale = Ralentizacion;
            o.SetActive(true);

        }
       

    }

    public void HideMenu()
    {
        foreach (GameObject o in menuElemets)
        {
            menuOut = false;
            Time.timeScale = 1.0f;
            o.SetActive(false);
        }
        UpdateLastShowed();
    }

    void UpdateLastShowed() {
        lastShow = DateTime.Now;
    }

    public static long GetTime(DateTime time) {
        return time.Ticks / TimeSpan.TicksPerMillisecond;
    }
}

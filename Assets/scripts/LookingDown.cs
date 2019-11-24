using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LookingDown : MonoBehaviour {
    private bool menuOut;
    GameObject[] menuElemets;
    public int TimeOutofMenu = 0;
    public int TimeLimit = 300;
    public float ToleranciaMirarSuelo = 0.766f;
    public float Ralentizacion = 0.3f;
    GameObject copyCanvas;
    public float Distance = 0.7f;
    public float Altura = 1.1F;
    public float YRotationCamera;
    public float YRotationCanvas;
    public long SecondDelay = 2;

    private DateTime lastShow;
    private float _alturaDefault;

    GameObject player;
    public bool Flying = false;

    // Start is called before the first frame update
    void Start() {
        menuElemets = GameObject.FindGameObjectsWithTag("MenuElements");
        copyCanvas = GameObject.FindGameObjectWithTag("Canvas");

        player = GameObject.FindGameObjectWithTag("Player");

        _alturaDefault = Altura;

        HideMenu();
        UpdateLastShowed();
    }

    // Update is called once per frame
    void Update() {
        // Debug.Log(TimeOutofMenu);
        //Debug.Log("x:" + gameObject.transform.eulerAngles.x);
        // Debug.Log("y:" + gameObject.transform.eulerAngles.y);
        //Debug.Log("z:" + gameObject.transform.eulerAngles.z);
        // Debug.Log(gameObject.transform.rotation.ToString());

        if (Vector3.Dot(gameObject.transform.forward, Vector3.down) > ToleranciaMirarSuelo) {
            if (!menuOut) {
                var now = GetTime(DateTime.Now);
                var lastUpdate = GetTime(lastShow);
                //if (lastUpdate + SecondDelay * 1000 >= now) {
                ShowMenu();
                UpdateLastShowed();
                //}
            }
            Debug.Log("I'm looking down!");

        } else {
            if (!Flying) {
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
            } else {
                if (!menuOut) {
                    ShowMenu();
                }
            }

        }
    }

    private void ShowMenu() {
        //if (!Flying) {
        //var position = new Vector3(transform.position.x, transform.position.y * Distance, transform.position.z);
        //copyCanvas.transform.position = position;
        //var rotation = Quaternion.LookRotation(transform.position);
        //rotation *= Quaternion.Euler(0, transform.rotation.y, 0);
        //copyCanvas.transform.rotation = Quaternion.Slerp(copyCanvas.transform.rotation, rotation, Time.deltaTime);
        //var c = copyCanvas;
        copyCanvas.GetComponent<BlockRotation>().Block = true;
        var a = new Vector3(copyCanvas.transform.position.x, copyCanvas.transform.position.y + Altura, copyCanvas.transform.position.z);
        copyCanvas.transform.position = a;
        //c.transform.LookAt(c.transform.position + transform.rotation * Vector3.back, transform.rotation * Vector3.up);

        if (!Flying) {
            foreach (GameObject o in menuElemets) {
                Time.timeScale = Ralentizacion;
                o.SetActive(true);
            }
        }
        menuOut = true;
        //}

    }

    public void HideMenu() {
        foreach (GameObject o in menuElemets) {
            Time.timeScale = 1.0f;
            o.SetActive(false);
        }
        menuOut = false;
        copyCanvas.GetComponent<BlockRotation>().Block = false;
        UpdateLastShowed();
    }

    public void UpdateLastShowed() {
        lastShow = DateTime.Now;
    }

    public static long GetTime(DateTime time) {
        return time.Ticks / TimeSpan.TicksPerMillisecond;
    }

    public void EnableFly() {
        Flying = true;
        Altura = _alturaDefault - 0.2f;
    }

    public void DisableFly() {
        Flying = false;
        Altura = _alturaDefault;
    }
}

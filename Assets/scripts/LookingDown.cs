using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LookingDown : MonoBehaviour {

    public int TimeOutofMenu = 0;
    public int TimeLimit = 300;
    public float ToleranciaMirarSuelo = 0.766f;
    public float Ralentizacion = 0.3f;
    public float Distance = 0.7f;
    public float Altura = 1.1F;
    public float YRotationCamera;
    public float YRotationCanvas;
    public long SecondDelay = 2;
    public bool Flying = false;

    private float _alturaDefault;
    private bool _menuOut;
    private GameObject[] _menuElemets;
    private GameObject copyCanvas;
    private DateTime _lastShow;

    // Start is called before the first frame update
    void Start() {
        _menuElemets = GameObject.FindGameObjectsWithTag("MenuElements");
        copyCanvas = GameObject.FindGameObjectWithTag("Canvas");

        _alturaDefault = Altura;

        HideMenu();
        UpdateLastShowed();
    }

    // Update is called once per frame
    void Update() {
        if (Vector3.Dot(gameObject.transform.forward, Vector3.down) > ToleranciaMirarSuelo) {
            if (!_menuOut) {
                ShowMenu();
                UpdateLastShowed();
            }

        } else {
            if (Vector3.Dot(gameObject.transform.forward, Vector3.down) > 0.166f) {
                TimeOutofMenu = 0;
            }
            if (TimeOutofMenu >= TimeLimit) {
                HideMenu();
                TimeOutofMenu = 0;
            } else {
                TimeOutofMenu++;

            }

        }
    }

    private void ShowMenu() {
        var y = copyCanvas.transform.position.y;

        foreach (GameObject o in _menuElemets) {
            Time.timeScale = Ralentizacion;
            o.SetActive(true);
        }
        if (!Flying) {
            y += Altura;
        }
        copyCanvas.GetComponent<BlockRotation>().Block = true;
        copyCanvas.transform.position = new Vector3(copyCanvas.transform.position.x, y, copyCanvas.transform.position.z);
        _menuOut = true;

    }

    public void HideMenu() {
        foreach (GameObject o in _menuElemets) {
            Time.timeScale = 1.0f;
            o.SetActive(false);
        }
        _menuOut = false;
        copyCanvas.GetComponent<BlockRotation>().Block = false;
        UpdateLastShowed();
    }

    public void UpdateLastShowed() {
        _lastShow = DateTime.Now;
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

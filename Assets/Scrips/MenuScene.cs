﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MenuScene : MonoBehaviour {

    public float totalTime = 5;
    public string scene = "MainScene";
    public float gvrTimer;
    public bool gvrStatus;
    public UnityEvent GVRClick;

    // Update is called once per frame
    void Update () {

        if (gvrStatus)
            gvrTimer += Time.deltaTime;

        if (gvrTimer > totalTime)
            GVRClick.Invoke();

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(scene);
    }


    public void GvrOn()
    {
        gvrStatus = true;
    }

    public void GvrOff()
    {
        gvrStatus = false;
        gvrTimer = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }
}

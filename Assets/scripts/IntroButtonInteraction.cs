using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class IntroButtonInteraction : MonoBehaviour
{

    public float totalTime = 3;
    public string scene = "StartMenu";
    public float gvrTimer;
    private bool gvrStatus;
    public UnityEvent GVRClick;

    // Update is called once per frame
    void Update()
    {

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
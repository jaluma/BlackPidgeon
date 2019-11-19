using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{
    public float totalTime = 1.5f;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 10;
    private RaycastHit _hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            float elapsed = gvrTimer / totalTime;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (elapsed >= totalTime && Physics.Raycast(ray, out _hit, distanceOfRay))
            {
                
                //if(_hit.transform.gameObject.GetComponent<Interactuable>()!=null)
                    _hit.transform.gameObject.GetComponent<Interactuable>().Execute();
                //print(_hit.transform.gameObject);
                GVROff();
            }
        }
    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
    }
}

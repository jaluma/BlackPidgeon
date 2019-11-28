using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{
    public float totalTime = 1.5f;
    bool gvrStatus;
    float gvrTimer;
    public Image reticula;

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
            reticula.fillAmount = gvrTimer / totalTime;
            //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = Camera.main.gameObject.transform.position;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            //Physics.Raycast(ray, out _hit, distanceOfRay)
            if (reticula.fillAmount >= 1 && results.Count>0)
            {
                results[0].gameObject.GetComponent<Interactuable>().Execute();
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
        reticula.fillAmount = 0;
    }
}

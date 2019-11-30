using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPalomasBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var canvas = GameObject.FindGameObjectWithTag("CanvasOverlay");
        EstadoJuego.numPalomas = 3;
        //for (var i = 0; i < EstadoJuego.numPalomas; i++)
        //{
        //    canvas.GetComponent<ImagePigeons>().AddPigeon();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

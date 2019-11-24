using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonInteraction : MonoBehaviour, Interactuable {
    private GameObject _canvas;

    // Start is called before the first frame update
    void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("CanvasOverlay");
    }

    public void Execute() {
        _canvas.GetComponent<ImagePigeons>().AddPigeon();
        Destroy(gameObject, 2);
    }
}

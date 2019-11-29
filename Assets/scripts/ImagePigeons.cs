using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePigeons : MonoBehaviour {
    private GameObject _canvas;
    private GameObject _imageDefault;
    private int _count;
    private GameObject[] _images;
    private int _countPigeons;
    public LanzarPalomas lanzar;

    // Start is called before the first frame update
    void Start() {
        _canvas = GameObject.FindGameObjectWithTag("CanvasOverlay");
        // disable copy elements
        _countPigeons = GameObject.FindGameObjectsWithTag("Pigeon").Length;
        _images = GameObject.FindGameObjectsWithTag("ImagePigeon");
        foreach (GameObject o in _images) {
            o.SetActive(false);
        }
        _imageDefault = _images[0];
        _count = 0;
    }

    // Update is called once per frame
    void Update() {
        actualizarPalomas();
    }

    public void AddPigeon() {
        // si es 0 significa que es la primera y hay que activar la de clonación
        if (_count < _countPigeons) {
            _images[_count++].SetActive(true);
        }
        lanzar.increasePalomasReclutadas();
    }

    public int GetCount()
    {
        return _count;
    }

    private void actualizarPalomas()
    {
        if (InfoPalomo.OtraEscena)
        {
            for (int i = 0; i < InfoPalomo.GetNumPalomas; i++)
                AddPigeon();
            InfoPalomo.OtraEscena = false;
        }
    }
}

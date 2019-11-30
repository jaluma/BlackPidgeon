using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePigeons : MonoBehaviour {
    private GameObject _canvas;
    private GameObject _imageDefault;
    private int _count;
    private GameObject[] _images;
    private int _countPigeons;
    private GameObject lanzar;

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
        lanzar = GameObject.FindGameObjectWithTag("Palomo");
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
        lanzar.GetComponent<LanzarPalomas>().increasePalomasReclutadas();
    }

    public int GetCount()
    {
        return _count;
    }

    private void actualizarPalomas()
    {
        if (EstadoJuego.OtraEscena)
        {
            int numPalomas = EstadoJuego.numPalomas;
            EstadoJuego.numPalomas = 0;
            for (int i = 0; i < numPalomas; i++)
                AddPigeon();
            EstadoJuego.OtraEscena = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePigeons : MonoBehaviour {
    private GameObject _canvas;
    private int _count;
    private GameObject _imageDefault;
    private int _countPigeons;
    public LanzarPalomas lanzar;

    // Start is called before the first frame update
    void Start() {
        _canvas = GameObject.FindGameObjectWithTag("CanvasOverlay");
        // disable copy elements
        _countPigeons = GameObject.FindGameObjectsWithTag("Pigeon").Length;
        var images = GameObject.FindGameObjectsWithTag("ImagePigeon");
        foreach (GameObject o in images) {
            o.SetActive(false);
        }
        _imageDefault = images[0];
        _count = 0;
    }

    // Update is called once per frame
    void Update() {
        actualizarPalomas();
    }

    public void AddPigeon() {
        // si es 0 significa que es la primera y hay que activar la de clonación
        if (_count == 0) {
            _imageDefault.SetActive(true);
        } else {
            if (_count < _countPigeons) {
                var image = Object.Instantiate(_imageDefault).gameObject;
                var copy = Instantiate(image, new Vector3(_imageDefault.transform.position.x + _count * 50, _imageDefault.transform.position.y, 0), Quaternion.identity);
                copy.transform.parent = transform;
                copy.SetActive(true);
            }
        }
        _count++;
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

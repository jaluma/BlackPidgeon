using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueAerio : MonoBehaviour
{

    private GameObject _proyectil_Original;
    private GameObject _proyectilNuevo;

    public GameObject Palomo;
    public GameObject Player;

    public float VelocidadProyectil = 10f;

    private Rigidbody _rb;
    public GameObject Canvas;
    public Vector3 Offset = new Vector3(0, 2f, 0);

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");

    }

    public void BombaVa()
    {
        if (GameObject.FindGameObjectWithTag("Palomo").GetComponent<PalomoController>().Flying)
        {
            _proyectil_Original = GameObject.FindGameObjectWithTag("poop");

            /*if (!_proyectil_Original.activeSelf)
            {
                _proyectil_Original.SetActive(true);
            }*/

            _proyectilNuevo = Instantiate(_proyectil_Original);

            //replay
            Palomo.GetComponent<PalomoController>().MaxSpeed = 0;
            Player.GetComponent<CameraController>().ObjectToFollow = _proyectilNuevo;

            Canvas.SetActive(false);
            Player.GetComponent<CameraController>().ChangePositionCamera(Offset);

            //_proyectil_Original.SetActive(false);
            _proyectilNuevo.transform.position = transform.position - new Vector3(0, 1, 0);
            _rb = _proyectilNuevo.GetComponent<Rigidbody>();
            _rb.velocity = new Vector3(0, -VelocidadProyectil, 0);
        }
        
    }
}

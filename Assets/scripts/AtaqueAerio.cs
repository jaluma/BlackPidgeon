using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueAerio : MonoBehaviour
{

    private GameObject _proyectil_Original;
    private GameObject _proyectilNuevo;

    public CameraController CController;
    public PalomoController PControler;

    public float VelocidadProyectil = 10f;

    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void BombaVa()
    {
        _proyectil_Original = GameObject.FindGameObjectWithTag("poop");

        /*if (!_proyectil_Original.activeSelf)
        {
            _proyectil_Original.SetActive(true);
        }*/
        
        _proyectilNuevo = Instantiate(_proyectil_Original);

       

        //replay
        PControler.MaxSpeed = 0;
        CController.ObjectToFollow = _proyectilNuevo;


        //_proyectil_Original.SetActive(false);
        _proyectilNuevo.transform.position = transform.position - new Vector3(0, 1, 0);
        _rb = _proyectilNuevo.GetComponent<Rigidbody>();
        _rb.velocity = new Vector3(0, -VelocidadProyectil, 0);
    }
}

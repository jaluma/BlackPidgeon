using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{

    public float Potencia = 10.0f;
    public float Radius = 5.0f;
    public float Upforce = 1.0f;

    public CameraController Player;
    public GameObject Palomo;


    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0)
        {
            ReplayCollision();
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Detonate();
    }
    void DelayedDestroy()
    {
        Destroy(this.gameObject);
    }

    private void Detonate()
    {
        Vector3 posicionExplosion = transform.position;
        Collider[] colliders = Physics.OverlapSphere(posicionExplosion, Radius);
        foreach(var hit in colliders)
        {
            var rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(Potencia, posicionExplosion, Radius, Upforce, ForceMode.Impulse);
            }
        }
        audioSource.Play();

        var r = new System.Random();
        int n = r.Next(0, colliders.Length);
        var o = colliders[n].gameObject;
       
        //replay

        if(colliders.Length > 2)
        {
            while (o.tag.Equals("poop") || o.tag.Equals("Ground"))
            {
                n = r.Next(0, colliders.Length);
                o = colliders[n].gameObject;
            }
            Player.ObjectToFollow = colliders[n].gameObject;

            StartCoroutine(Wait());

            ReplayCollision();

        }
        else
        {
            StartCoroutine(Wait());
            ReplayCollision();
        }

        Invoke("DelayedDestroy", 0.5F);

    }
    //makes the code wait for 2 ingame seconds
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }

    /**
     * Hace que la camara vuelva a seguir a palomo y lo pone en movimiento de nuevo
     * Velocidad palomo debería de ser la misma que la original
     */
    private void ReplayCollision()
    {

        Player.ObjectToFollow = Palomo;

        var pController = Palomo.GetComponent<PalomoController>();
        pController.ResetMaxSpeed();
        Player.GetComponent<CameraController>().ResetPositionCamera();

        Palomo.GetComponent<AtaqueAerio>().Canvas.SetActive(true);

    }
}

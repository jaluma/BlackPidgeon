using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{

    public float Potencia = 10.0f;
    public float Radius = 5.0f;
    public float Upforce = 1.0f;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider collider)
    {
        Debug.Log(collider.gameObject.name);
        Detonate();
        Invoke("DelayedDestroy", 2);
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
    }
}

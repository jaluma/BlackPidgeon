using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayorShooting : MonoBehaviour
{
    public /*GameObject*/Rigidbody bulletPrefab;
    public float shootSpeed = 300;
    public GameObject enemy;

    Transform cameraTransform;
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootBullet();
        }
    }
    void shootBullet()
    {/*
        GameObject tempObj;
        //Instantiate/Create Bullet
        
        tempObj = Instantiate(bulletPrefab) as GameObject;

        //Set position  of the bullet in front of the player
        tempObj.transform.position = transform.position;

        //Get the Rigidbody that is attached to that instantiated bullet
        Rigidbody projectile = GetComponent<Rigidbody>();

        //Shoot the Bullet 
        projectile.velocity = cameraTransform.forward * shootSpeed;*/

        Rigidbody bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as Rigidbody;
        bullet.velocity = cameraTransform.TransformDirection(Vector3.forward * shootSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayorShooting : MonoBehaviour
{
    public /*GameObject*/Rigidbody bulletPrefab;
    public float shootSpeed = 300;
    public GameObject enemy;
    public float fireRate = 3;
    private float nextFire = 2;

    Transform cameraTransform;
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            ShootBullet(); 
        }
        
    }
    void ShootBullet()
    {
        transform.LookAt(enemy.transform.position);
        Rigidbody bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as Rigidbody;
        //bullet.velocity = cameraTransform.TransformDirection(Vector3.forward * shootSpeed);
        Destroy(bullet.gameObject, 10f);
    }

}

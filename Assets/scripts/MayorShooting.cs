using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MayorShooting : MonoBehaviour
{
    public Rigidbody BulletPrefab;
    public GameObject EnemyToShoot;

    private int count = 0;
    private int _fireRate = 3;

    void Update()
    {
        transform.LookAt(EnemyToShoot.transform);
        if (count++ >= _fireRate * 100)
        {
            ShootBullet();
            count = 0;
        }

    }
    void ShootBullet()
    {
        //new Vector3(transform.rotation.normalized.x, transform.rotation.normalized.y, transform.rotation.normalized.z)
        Rigidbody bullet = Instantiate(BulletPrefab, transform.position, transform.rotation) as Rigidbody;
        bullet.AddForce(transform.forward.normalized * 1000);
        bullet.transform.parent = GameObject.FindGameObjectWithTag("BulletCollection").transform;
        Destroy(bullet.gameObject, 10f);
    }
}

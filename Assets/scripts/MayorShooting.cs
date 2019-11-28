using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MayorShooting : MonoBehaviour
{
    public Rigidbody BulletPrefab;
    public GameObject EnemyToShoot;
    private float _fireRate = 3;
    private float _nextFire = 2;

    void Update()
    {
        transform.LookAt(EnemyToShoot.transform);
        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            ShootBullet();
        }

    }
    void ShootBullet()
    {
        Rigidbody bullet = Instantiate(BulletPrefab, transform.position, new Quaternion()) as Rigidbody;
        bullet.transform.parent = GameObject.FindGameObjectWithTag("BulletCollection").transform;
        Destroy(bullet.gameObject, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("poop"))
        {
            SceneManager.LoadScene("Credits");
        }
    }
}

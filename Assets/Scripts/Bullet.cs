using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] Transform firePoint;
    [SerializeField] float bulletSpeed;

    private void Start()
    {
        rigid.velocity = transform.forward * bulletSpeed;
        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}

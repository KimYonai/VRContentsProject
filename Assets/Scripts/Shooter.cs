using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] AudioSource fireSound;
    Coroutine fireRoutine;

    public void StartFire()
    {
        fireRoutine = StartCoroutine(FireRoutine());
    }

    public void StopFire()
    {
        StopCoroutine(fireRoutine);
    }

    IEnumerator FireRoutine()
    {
        GameObject bulletObj = Instantiate(bullet, firePoint.position, firePoint.rotation);
        fireSound.Play();
        yield return new WaitForSeconds(1.0f);
    }
}

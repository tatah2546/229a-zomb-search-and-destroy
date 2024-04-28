using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPosition;


    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 20, ForceMode2D.Impulse);
    }
}

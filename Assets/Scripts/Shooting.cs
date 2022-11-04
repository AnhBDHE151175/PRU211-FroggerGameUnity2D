using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulltetPrefab;
    public float bultetforece = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulltetPrefab, firepoint.position, firepoint.rotation);
        // Rigidbody2D rb= bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * bultetforece, ForceMode2D.Impulse);
        //rb.AddForce(firepoint.up * bultetforece, ForceMode2D.Impulse);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * bultetforece, ForceMode2D.Impulse);
        Destroy(bullet, 2);
    }
}
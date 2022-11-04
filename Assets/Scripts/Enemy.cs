using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject findPlayer;

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public float bultetforece = 5f;
    //public GameObject bulletPrefab;
    // public Transform firepoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //findPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 direction = findPlayer.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        // int rnd= Random.Range(0, 500);
        //if (rnd ==1)
        //{
        //    Shoot();
        //}


    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    //private void Shoot()
    //{
    //    GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    //    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    //    rb.AddForce(firepoint.up * bultetforece, ForceMode2D.Impulse);

    //}

}
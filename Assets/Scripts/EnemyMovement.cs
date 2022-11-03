using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float enemySpeed;
    Rigidbody2D enemyRB;

    Animator enemyAnim;

    public GameObject enemyGraphic;
    bool facingRight = true;
    float facingTime = 3f;
    float nextFlip = 0f;
    bool canFlip = true;


    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponentInChildren<Animator>();
    }
    void Start()
    {

    }


    void Update()
    {
        if (Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            flip();
        }

    }

    void flip()
    {
        if (!canFlip)
            return;
        facingRight = !facingRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flip();
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                flip();
            }
            canFlip = false;
        }

    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!facingRight)
                enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
            else
                enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
            enemyAnim.SetBool("Run", true);

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            enemyRB.velocity = new Vector2(0, 0);
            enemyAnim.SetBool("Run", false);
        }
    }

}

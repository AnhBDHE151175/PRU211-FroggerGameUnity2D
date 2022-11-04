using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    Animator ani;
    Vector2 movement;
    Vector2 MousePos;
    [SerializeField]
    Rigidbody2D rb;
    public float speed = 10f;
    [SerializeField]
    Camera cam;
    void Start()
    {
        ani = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        InputAction();

    }
    private void FixedUpdate()
    {
        Movement_Rotation();

    }
    void InputAction()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ani.SetBool("isFire", true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            ani.SetBool("isFire", false);
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void Movement_Rotation()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookdir = MousePos - rb.position;
        float Angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = Angle;
    }
}
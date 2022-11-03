using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    public float boomSpeedHight;
    public float boomSpeedLow;
    public float boomAngle;

    Rigidbody2D cannonRB;
    // Start is called before the first frame update

    void Awake()
    {
        cannonRB = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        cannonRB.AddForce(new Vector2(Random.Range(-boomAngle, boomAngle), Random.Range(boomSpeedLow, boomSpeedHight)), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
    }
}

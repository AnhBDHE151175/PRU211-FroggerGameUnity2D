using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarShoot : MonoBehaviour
{
    public GameObject theBoom;
    public Transform shootForm;
    public float shootTime;

    float nextShoot = 0f;
    Animator cannonAnim;

    void Awake()
    {
        cannonAnim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Time.time > nextShoot)
        {
            nextShoot = Time.time + shootTime;
            Instantiate(theBoom, shootForm.position, Quaternion.identity);
            cannonAnim.SetTrigger("cannonShoot");
        }

    }
}

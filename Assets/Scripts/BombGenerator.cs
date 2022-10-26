using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    public GameObject Bomb;
    public GameObject Frog;
    public float minBoomTime = 1;
    public float maxBoomTime = 2;

    private float lastBoomTime = 0;
    private float boomTime = 0;


    private Animator animator;
    void Start()
    {
        UpdateBombTime();
        Frog = GameObject.FindGameObjectWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("Load");
    }

    void Update()
    {
        if(Time.time >= lastBoomTime + boomTime)
        {
            BommbGenerate();
            animator.SetTrigger("Load");
        }
    }
    void UpdateBombTime()
    {
        lastBoomTime = Time.time;
        boomTime = Random.Range(minBoomTime, maxBoomTime + 1);
    }
    void BommbGenerate()
    {
        animator.SetTrigger("Fire");
        GameObject bomb = Instantiate(Bomb, transform.position, Quaternion.identity) as GameObject;
        bomb.GetComponent<BombNavigator>().target = Frog.transform.position;
        UpdateBombTime();
    }
}

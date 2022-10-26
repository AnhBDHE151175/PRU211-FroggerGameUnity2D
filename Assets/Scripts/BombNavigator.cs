using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombNavigator : MonoBehaviour
{
    public Vector3 target;
    public float moveSpeed = 5;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((transform.position - target) * moveSpeed * Time.deltaTime * -1);
    }

    /*void BoomNavagate()
    {
        transform.Translate((transform.position - target) * moveSpeed * Time.deltaTime);
    }*/
}

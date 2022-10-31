using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombNavigator : MonoBehaviour
{
    public Vector3 target;
    public float moveSpeed = 2;
    public float destroyTime = 1;

    public GameObject explode;
    // Start is called before the first frame update

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((transform.position - target) * moveSpeed * Time.deltaTime * -1);
    }


    void OnDestroy()
    {
        GameObject exploder = Instantiate(explode, transform.position, Quaternion.identity);
        Destroy(exploder, 0.5f);
    }
}

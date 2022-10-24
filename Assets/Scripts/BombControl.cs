using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : MonoBehaviour
{
    public float radius = 1f;

    public LayerMask mask;

    public void Bomb()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, mask);
        foreach(var collider in colliders)
        {
            Destroy(collider.gameObject);
        }
        Destroy(this.gameObject);
    }
}

<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frogger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move(Vector3 direction)
    {
        Vector3 desitination = transform.position + direction;
        Collider2D barrier = Physics2D.OverlapBox(desitination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        Collider2D platform = Physics2D.OverlapBox(desitination, Vector2.zero, 0f, LayerMask.GetMask("Platform"));
        if(barrier != null)
        {
            return;
        }

        if(platform != null)
        {
            transform.SetParent(platform.transform);
        }
        else
        {
            transform.SetParent(null);
        }
        
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frogger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
>>>>>>> main

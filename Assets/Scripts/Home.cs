using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Home : MonoBehaviour
{
    public GameObject frog;
 

   

    private void OnEnable()
    {
        frog.SetActive(true);
      
    }

    private void OnDisable()
    {
        frog.SetActive(false);
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled && other.gameObject.CompareTag("Player"))
        {
            enabled = true;
            FindObjectOfType<Frogger>().Respawn();
        }
    }

}

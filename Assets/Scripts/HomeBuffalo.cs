using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HomeBuffalo : MonoBehaviour
{
    public GameObject buffalo;
    private BoxCollider2D boxCollider;


    private void OnEnable()
    {
        buffalo.SetActive(true);

    }

    private void OnDisable()
    {
        buffalo.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enabled = true;
            //Buffalo bu = other.GetComponent<Buffalo>();
            //bu.gameObject.SetActive(false);
            //bu.Invoke(nameof(bu.Respawn), 1f);
            FindObjectOfType<GameManagerForBuffalo>().HomeOccupied();
        }
    }

}

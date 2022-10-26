
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Frogger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite leapSprite;
    public Sprite deadSprite;

    private Vector3 spawnPosition;
    private float farthestRow;
    private bool cooldown;

    public Text txtScore;

    private void Start()
    {
        txtScore = GameObject.Find("TextScore").GetComponent<Text>();
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawnPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Move(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            Move(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            Move(Vector3.right);
        }

    }

    private void Move(Vector3 direction)
    {
        Vector3 desitination = transform.position + direction;
        Collider2D barrier = Physics2D.OverlapBox(desitination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        Collider2D platform = Physics2D.OverlapBox(desitination, Vector2.zero, 0f, LayerMask.GetMask("Platform"));
        Collider2D obstacle = Physics2D.OverlapBox(desitination, Vector2.zero, 0f, LayerMask.GetMask("Obstacle"));

        Debug.Log(barrier);
        Debug.Log(platform);

        if (barrier != null)
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

        if (obstacle != null)
        {
            transform.position = desitination;
            Death();
        }
        else
        {
            StartCoroutine(Leap(desitination));
        }
    }
    

    private void Death()
    {
        StopAllCoroutines();
        transform.rotation = Quaternion.identity;
        spriteRenderer.sprite = deadSprite;
        enabled = false;
        Invoke(nameof(Respawn), 1f);
    }
    private IEnumerator Leap(Vector3 destination)
    {
        Vector3 startPosition = transform.position;
        float elapsed = 0f;
        float duration = 0.125f;

        spriteRenderer.sprite = leapSprite;

        while(elapsed < duration)
        {
            float time = elapsed / duration;
            transform.position = Vector3.Lerp(startPosition, destination, time);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = destination;
        spriteRenderer.sprite = idleSprite;

    }
    public void Respawn()
    {
        StopAllCoroutines();
        transform.rotation = Quaternion.identity;
        transform.position = spawnPosition;
        spriteRenderer.sprite = idleSprite;
        enabled = true;
    }

    int score = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool hitCoin = other.gameObject.layer == LayerMask.NameToLayer("Coin");
        if (enabled && hitCoin)
        {
            score += 1;
            txtScore.text = "Score: " + score.ToString();
            Destroy(other.gameObject);
        }
    }
}

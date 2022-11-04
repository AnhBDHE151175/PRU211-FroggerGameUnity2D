
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

    public AudioSource aus;
    public AudioClip moveSound;
    public AudioClip loseSound;

    private void Start()
    {
        txtScore = GameObject.Find("TextScore").GetComponent<Text>();
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawnPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Move(Vector3.up);
            if(aus && moveSound)
            {
                aus.PlayOneShot(moveSound);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            Move(Vector3.down);
            if (aus && moveSound)
            {
                aus.PlayOneShot(moveSound);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            Move(Vector3.left);
            if (aus && moveSound)
            {
                aus.PlayOneShot(moveSound);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            Move(Vector3.right);
            if (aus && moveSound)
            {
                aus.PlayOneShot(moveSound);
            }
        }

    }

    private void Move(Vector3 direction)
    {
        if (cooldown)
        {
            return;
        }
        Vector3 destination = transform.position + direction;
        Collider2D platform = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Platform"));
        Collider2D obstacle = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Obstacle"));
        Collider2D barrier = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        if (barrier != null && platform!=null)
        {
            return;
        }
        if (platform != null)
        {
            transform.SetParent(platform.transform);
        }
        else
        {
            transform.SetParent(null);
        }
        if (obstacle != null && platform == null)
        {
            transform.position = destination;
            Death();
        }
        else
        {
            if (destination.y > farthestRow)
            {
                farthestRow = destination.y;
                FindObjectOfType<GameManager>().AdvancedRow();
            }
            StopAllCoroutines();
            StartCoroutine(Leap(destination));
        }
    }


    public void Death()
    {
        
        StopAllCoroutines();
        enabled = false;
        transform.rotation = Quaternion.identity;
        spriteRenderer.sprite = deadSprite;
        FindObjectOfType<GameManager>().Died();
        if (aus && moveSound)
        {
            aus.PlayOneShot(loseSound);
        }
       
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
        farthestRow = spawnPosition.y;
        spriteRenderer.sprite = idleSprite;
        gameObject.SetActive(true);
        enabled = true;
        cooldown = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool hitCoin = other.gameObject.layer == LayerMask.NameToLayer("Coin");
        bool hitObstacle = other.gameObject.layer == LayerMask.NameToLayer("Obstacle");
        bool onPlatform = transform.parent != null;
        if (enabled && hitObstacle && !onPlatform)
        {
            Death();
        }
        if (enabled && hitCoin)
        {
            FindObjectOfType<GameManager>().HitCoin();
            Destroy(other.gameObject);
        }
    }
}

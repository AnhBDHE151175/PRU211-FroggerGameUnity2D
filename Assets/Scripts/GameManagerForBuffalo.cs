using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class GameManagerForBuffalo : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public Text timeText;
    private Buffalo buffalo;
    private HomeBuffalo[] homes;
    private int score;
    private int lives;
    private int time;
    public GameObject gameOverMenu;
    public GameOverScreen gameOverScreen;
    public WinGameScreen WinGameScreen;

    private void Start()
    {
        NewGame();
    }
    private void NewGame()
    {
        gameOverMenu.SetActive(false);
        SetScore(0);
        SetLives(3);
        NewLevel();
    }

    public void Died()
    {
        SetLives(lives - 1);
        if(lives > 0)
        {
            Invoke(nameof(Respawn), 1f);
        }
        else
        {
            Invoke(nameof(GameOver), 1f);
            Application.Quit();
        }
    }

    private IEnumerator PlayAgain()
    {
        bool playAgain = false;
        while(!playAgain)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
            playAgain = true;
            }
            yield return null;
        }
        NewGame();
    }
    public void HitCoin()
    {
        SetScore(score + 20);
    }
    private void GameOver()
    {
        buffalo.gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(PlayAgain());
        gameOverScreen.Setup(0);
    }

    private void Awake()
    {
        homes = FindObjectsOfType<HomeBuffalo>();
        buffalo = FindObjectOfType<Buffalo>();
    }

    private void NewLevel()
    {
        for (int i = 0; i < homes.Length; i++)
        {
            homes[i].enabled = false;
        }
        Respawn();
    }
    public void AdvancedRow()
    {
        SetScore(score + 10);
    }
    public void HomeOccupied()
    {
        buffalo.gameObject.SetActive(false);
        int bonusPoints = time * 20;
        SetScore(score + 50);
        if (Cleared())
        {
            WinGameScreen.Setup(0);
            SetScore(score + 500);
            SetLives(lives + 1);
            Invoke(nameof(NewLevel),1f);
        }
        else
        {
            Invoke(nameof(Respawn),1f);
        }
    }
    private bool Cleared()
    {
        for(int i = 0; i < homes.Length; i++)
        {
            if (!homes[i].enabled)
            {
                return false;
            }
        }
        return true;
    }


    private void Respawn()
    {
        buffalo.Respawn();
        StopAllCoroutines();
        StartCoroutine(Timer(30));
    }
    private IEnumerator Timer(int duration)
    {
        time = duration;
        timeText.text = time.ToString();
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            timeText.text = time.ToString();
        }

        buffalo.Death();
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = lives.ToString();
    }
}

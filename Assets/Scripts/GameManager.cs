using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Home[] homes; 
    private int lives;

    private int time;
    private int score;


    Frogger frogger;
    private void Awake()
    {
        homes = FindObjectsOfType<Home>();  
        frogger = FindObjectOfType<Frogger>();
    }
    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewLevel();
    }
    private void NewLevel()
    {
        for(int i = 0; i< homes.Length; i++)
        {
            homes[i].enabled = false;
        }
        NewRound();
        
    }

    private void NewRound()
    {
        frogger.Respawn();
    }
    public void HomeOccupied()
    {
        frogger.gameObject.SetActive(false);
        if (Cleared())
        {
            Invoke(nameof(NewLevel), 1f);
        }
        else
        {
            Invoke(nameof(NewRound), 1f);
        }
    }

    public bool Cleared()
    {
        for (int i = 0; i < homes.Length; i++)
        {
            if (!homes[i].enabled)
            {
                return false;
            }   
        }
        return true;
    }
    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    private void GameOver()
    {

    }
}
  

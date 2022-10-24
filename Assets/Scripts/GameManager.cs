using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int lives;

    private int time;

    Frogger frogger;
    private void Awake()
    {
        frogger = FindObjectOfType<Frogger>();
    }
    private void NewGame()
    {
        SetLives(3);
    }
private void NewLevel()
    {

    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }
//public void Died()
//    {
//        SetLives(lives - 1);
//        if(lives > 0)
//        {
//            Invoke(nameof(Respawn), 1f);
//        }
//        else
//        {
//            Invoke(nameof(GameOver), 1f);
//        }
//    }
    private void GameOver()
    {

    }
    //private IEnumerator Timer(int duration)
    //{
    //    time = duration;
    //    while(time > 0)
    //    {
    //        yield return WaitForSeconds(1);
    //        time--;
    //    }
    //    frogger.Death
    //}
    //private void Respawn()
    //{
    //    frogger.Respawn();
    //    StopAllCoroutines();
    //    StartCoroutine(Timer(30));
    //}
}

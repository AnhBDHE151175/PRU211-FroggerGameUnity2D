using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinGameScreen : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }
    public void PlayAgainButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void PlayAgainButtonLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void PlayAgainButtonKVN()
    {
        SceneManager.LoadScene("Kvan_Scene");
    }
    public void PlayAgainButtonDA()
    {
        SceneManager.LoadScene("DucAnhScenes");
    }
    public void BackToMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}

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
    public void BackToMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}

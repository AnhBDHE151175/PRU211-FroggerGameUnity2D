using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString()+ " POINTS";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAgainButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void BackToMenuButton()
    {
        SceneManager.LoadScene("Menu");
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
}

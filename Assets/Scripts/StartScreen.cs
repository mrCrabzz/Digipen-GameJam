using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void StartTheGame()
    {
        GameManager.Score = 0;
        GameManager.HardScore = 0;
        SceneManager.LoadScene("KirillScene");
    }

    public void StartHardMode()
    {
        GameManager.Score = 0;
        GameManager.HardScore = 0;
        SceneManager.LoadScene("HardMode");
    }

    public void StartPreviousScene()
    {
        if (GameManager.isNormalMode == true)
        {
            SceneManager.LoadScene("KirillScene");
            GameManager.Score = 0;
            GameManager.HardScore = 0;
        }
        else if (GameManager.isHardMode == true)
        {
            SceneManager.LoadScene("HardMode");
            GameManager.Score = 0;
            GameManager.HardScore = 0;
        }
        else
        {
            SceneManager.LoadScene("KirillScene");
            GameManager.Score = 0;
            GameManager.HardScore = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

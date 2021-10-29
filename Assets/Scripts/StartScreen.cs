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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreText : MonoBehaviour
{
    TMP_Text HighScore;

    // Start is called before the first frame update
    void Start()
    {
        HighScore = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //sets the text to the score
        HighScore.text = "High Score: " + GameManager.HighScore;
    }
}

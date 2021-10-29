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
        //checks which score is higher
        //score is set to zero when scene is reloaded
        //so the correct score will always be higher
        if (GameManager.isNormalMode == true)
        {
            HighScore.text = "High Score: " + GameManager.HighScore;
        }
        else if (GameManager.isHardMode == true)
        {
            HighScore.text = "High Score: " + GameManager.HardHighScore;
        }
    }
}

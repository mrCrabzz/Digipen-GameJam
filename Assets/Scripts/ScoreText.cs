using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    TMP_Text Score;

    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //sets the text to the score
        //checks which score is higher
        //score is set to zero when scene is reloaded
        //so the correct score will always be higher
        if (GameManager.isNormalMode == true)
        {
            Score.text = "Score: " + GameManager.Score;
        }
        else if(GameManager.isHardMode == true)
        {
            Score.text = "Score: " + GameManager.HardScore;
        }
    }
}

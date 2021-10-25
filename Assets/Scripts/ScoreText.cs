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
        Score.text = "Score: " + GameManager.Score;
    }
}

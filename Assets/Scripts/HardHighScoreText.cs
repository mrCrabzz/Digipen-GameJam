using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HardHighScoreText : MonoBehaviour
{
    TMP_Text HardHighScore;

    // Start is called before the first frame update
    void Start()
    {
        HardHighScore = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //sets the text to the score
        HardHighScore.text = "High Score: " + GameManager.HardHighScore;
    }
}

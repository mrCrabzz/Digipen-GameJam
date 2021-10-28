using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    TMP_Text Health;
    Health Player;

    // Start is called before the first frame update
    void Start()
    {
        Health = GetComponent<TMP_Text>();
        Player = GameObject.Find("guy1").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        //sets the text to the score
        Health.text = "Health: " + Player.CurrentHealth;

    }
}

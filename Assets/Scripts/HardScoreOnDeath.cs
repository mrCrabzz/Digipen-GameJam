using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardScoreOnDeath : MonoBehaviour
{
    public int HardPoints = 5;

    private void OnDeath()
    {
        GameManager.HardScore += HardPoints;
    }
    // Start is called before the first frame update
    void Start()
    {
        Death D = GetComponent<Death>();
        if (D != null)
        {
            D.OnDeath.AddListener(OnDeath);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

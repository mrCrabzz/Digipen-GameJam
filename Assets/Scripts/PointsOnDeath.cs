using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOnDeath : MonoBehaviour
{
    public int Points = 5;

    private void OnDeath()
    {
        GameManager.Score += Points;
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

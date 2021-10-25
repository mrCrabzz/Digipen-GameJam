using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{

    public float DeathTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CauseDeath());
    }

    //causes death after a delay
    IEnumerator CauseDeath()
    {
        yield return  new WaitForSeconds(DeathTime);
        Death D = GetComponent<Death>();
        if (D != null)
        {
            D.OnDeath.Invoke();
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

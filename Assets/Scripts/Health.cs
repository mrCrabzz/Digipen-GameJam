using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int CurrentHealth = 10;
    public int MaxHealth = 10;

    public bool DestroyAtZero = true;

    public float DeathTime = 0.2f;

    bool isDying = false;
    //Call this to change the health object
    public void HealthChange (int change)
    {
        CurrentHealth += change;
        if(CurrentHealth <= 0)
        {
            //optional but this will prevent negative health
            CurrentHealth = 0;
            if(DestroyAtZero)
            {
                Death D = GetComponent<Death>();
                if (D != null && !isDying)
                {
                    D.OnDeath.Invoke();
                }
                StartCoroutine(TimedDestroy());
                
            }
            if(CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }
    }

    IEnumerator TimedDestroy()
    {
        yield return new WaitForSeconds(DeathTime);
        Destroy(gameObject);
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

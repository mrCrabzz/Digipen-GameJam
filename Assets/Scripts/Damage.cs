using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    float Cooldown = 0.5f;
    float Timer = 0;

    public int Amount = 4;
    public bool DestroyOnCollide = true;

    //happens once when collision of two objects starts
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Timer += Time.deltaTime;
        Health H= collision.gameObject.GetComponent<Health>();
        if(H != null && Timer >= Cooldown)
        {
            H.HealthChange(-Amount);
        }
        if(DestroyOnCollide)
        {
            Destroy(gameObject);
        }
    }
    //happens once when the collision of two objects stops
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
    //happen every frame that two objects collide
    private void OnCollisionStay2D(Collision2D collision)
    {
        Timer += Time.deltaTime;
        Health H = collision.gameObject.GetComponent<Health>();
        if (H != null && Timer >= Cooldown)
        {
            H.HealthChange(-Amount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Timer += Time.deltaTime;
        Health H = collision.GetComponent<Health>();
        if (H != null && Timer >= Cooldown)
        {
            H.HealthChange(-Amount);
        }
        if (DestroyOnCollide)
        {
            Death D = GetComponent<Death>();
            if (D != null)
            {
                D.OnDeath.Invoke();
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Timer += Time.deltaTime;
        Health H = collision.GetComponent<Health>();
        if (H != null && Timer >= Cooldown)
        {
            H.HealthChange(-Amount);
        }
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

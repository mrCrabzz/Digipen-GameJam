using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    

    public float PaceSpeed = 2;
    public float ChaseDistance = 4;
    public float ChaseSpeed = 5;

    [Tooltip("Chose the object the AI is searching for within the chase distance")]
    public GameObject Target;

    

    Rigidbody2D myRb;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Player");
        myRb = GetComponent<Rigidbody2D>();
    }




    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        //make sure target exists
        if (Target != null)
        {
            //grab the vector to the player
            Vector2 direction = Target.transform.position - transform.position;
            //check if within chase distance or not
            if (direction.sqrMagnitude <= ChaseDistance * ChaseDistance)
            {
                Chase(direction);
            }
            else
            {
                Pace(direction);
            }
        }

    }

    void Pace(Vector2 direction)
    {
        
        //set movement towards current target
        //normalize to make length 1
        direction = direction.normalized;
        myRb.velocity = direction * PaceSpeed;
    }

    void Chase(Vector2 direction)
    {
        direction = direction.normalized;
        myRb.velocity = direction * ChaseSpeed;
    }
}

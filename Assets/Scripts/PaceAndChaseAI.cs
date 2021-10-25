using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaceAndChaseAI : MonoBehaviour
{
    [Tooltip("Insert the list of points you want the AI to pace through")]
    public Vector3[] Points = { new Vector3(0, 0, 0), new Vector3(5, 0, 0) };

    public int CurrentPoint = 0;

    public float PaceSpeed = 2;

    public float CloseEnough = 0.3f;

    public float ChaseDistance = 4;
    [Tooltip("Chose the object the AI is searching for within the chase distance")]
    public GameObject Target;

    public float ChaseSpeed = 5;

    Rigidbody2D myRb;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }




    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        //make sure target exists
        if(Target != null)
        {
            //grab the vector to the player
            Vector2 direction = Target.transform.position - transform.position;
            //check if within chase distance or not
            if(direction.sqrMagnitude <= ChaseDistance * ChaseDistance)
            {
                Chase(direction);
            }
            else
            {
                Pace();
            }
        }
        else
        {
            Pace();
        }
        
    }

    void Pace()
    {
        //check if near current target point if so, move to next
        Vector3 direction = Points[CurrentPoint] - transform.position;
        float distSquared = direction.sqrMagnitude;
        if(distSquared < CloseEnough)
        {
            CurrentPoint++;
            if(CurrentPoint >= Points.Length)
            {
                CurrentPoint = 0;
            }
            direction = Points[CurrentPoint] - transform.position;
        }
        //set movement towards current target
        //normalize to make length 1
        direction = direction.normalized;
        myRb.velocity = direction * PaceSpeed;
    }

    void Chase( Vector2 direction)
    {
        direction = direction.normalized;
        myRb.velocity = direction * ChaseSpeed;
    }

}

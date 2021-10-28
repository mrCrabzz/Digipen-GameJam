using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{

    

    public float PaceSpeed = 20;
    public float ChaseDistance = 30;
    public float ChaseSpeed = 1;

    [Tooltip("Chose the object the AI is searching for within the chase distance")]
    public GameObject Target;

    

    Rigidbody2D myRb;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("guy1");
        myRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        

        //transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
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
                Chase(direction, ChaseSpeed);
            }
            else
            {
                Chase(direction, PaceSpeed);
            }
            Vector3 dir = Target.transform.position - transform.position;
            dir = dir.normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }

    void Chase(Vector2 direction, float speed)
    {
        direction = direction.normalized;
        myRb.velocity = direction * speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kmovement : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*float movex = 0f;
        float movey = 0f;
        if (Input.GetKey("left"))
        {
            movex -= speed;
        }
        if (Input.GetKey("right"))
        {
            movex += speed;
        }
        if (Input.GetKey("down"))
        {
            movey -= speed;
        }
        if (Input.GetKey("up"))
        {
            movey += speed;
        }*/
        //GetComponent<Rigidbody2D>().velocity = new Vector2(movex, movey);
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //GetComponent<Rigidbody2D>().velocity = new Vector2(movex, movey);
        if (Input.GetKey("left"))
        {
            transform.position += transform.up * Time.deltaTime * -speed;
        }
        if (Input.GetKey("right"))
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }
        if (Input.GetKey("down"))
        {
            transform.position += transform.right * Time.deltaTime * -speed;
        }
        if (Input.GetKey("up"))
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }

    }
}

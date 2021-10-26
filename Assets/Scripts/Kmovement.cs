using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kmovement : MonoBehaviour
{
    [Tooltip("Drag the laser prefab here to use")]
    public GameObject Laser;

    public float Cooldown = 0.2f;
    float Timer = 0;
    public float LaserSpeed = 15;
    public Vector3 Offset1 = new Vector3(.4f, .8f, 0);
    


    //FollowingCamera FC;
   // public float FireShakeTime = 0.1f;
   // public float FireShakeMag = 0.2f;

    //audio things
    AudioSource myAudio;
    public AudioClip LaserSound;


    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movex = 0f;
        float movey = 0f;
        if (Input.GetKey("a"))
        {
            if (this.transform.position.x > -20f)
            {
                movex -= speed;
            }
        }
        if (Input.GetKey("d"))
        {
            if (this.transform.position.x < 48f)
            {
                movex += speed;
            }
        }
        if (Input.GetKey("s"))
        {
            if (this.transform.position.y > -30f) {     
                movey -= speed; 
            }
        }
        if (Input.GetKey("w"))
        {
            if (this.transform.position.y < 45f)
            {
                movey += speed;
            }
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(movex, movey);
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //GetComponent<Rigidbody2D>().velocity = new Vector2(movex, movey);
        /*if (Input.GetKey("left"))
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
        }*/

        Timer += Time.deltaTime;
        if (Input.GetAxisRaw("Jump") == 1 && Timer >= Cooldown)
        {
            //make laser noise
            //myAudio.PlayOneShot(LaserSound);
            //fire objects
            Fire(Offset1);
            
            Timer = 0;
        }
    }
    void Fire(Vector3 offset)
    {
        Vector3 spawnpos = transform.position + transform.rotation * offset;
        GameObject las1 = Instantiate(Laser, spawnpos, transform.rotation);

        las1.GetComponent<Rigidbody2D>().velocity = transform.right * LaserSpeed;

        //FC.TriggerShake(FireShakeTime, FireShakeMag);
    }
}

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
    public Vector3 Offset1 = new Vector3(-.4f, .8f, 0);
    private AudioSource source;


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
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float movex = 0f;
        float movey = 0f;
        if (Input.GetKey("a"))
        {
            if (this.transform.position.x > -33f)
            {
                movex -= speed;
            }
        }
        if (Input.GetKey("d"))
        {
            if (this.transform.position.x < 33f)
            {
                movex += speed;
            }
        }
        if (Input.GetKey("s"))
        {
            if (this.transform.position.y > -36f) {     
                movey -= speed; 
            }
        }
        if (Input.GetKey("w"))
        {
            if (this.transform.position.y < 36f)
            {
                movey += speed;
            }
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(movex, movey);
        
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        //transform.eulerAngles = new Vector3(0, 0, angle);
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
        if ((Input.GetAxisRaw("Jump") == 1 || Input.GetAxisRaw("Fire1") == 1) && Timer >= Cooldown)
        {
            //make laser noise
            //myAudio.PlayOneShot(LaserSound);
            //fire objects
            Fire(Offset1);
            
            Timer = 0;
            source.Play();
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

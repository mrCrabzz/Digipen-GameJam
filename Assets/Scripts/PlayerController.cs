using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [Tooltip("Speed the object can move forward and back (acceleration)")]
    public float Speed = 1000;
    [Tooltip("Speed the object can turn left and right (acceleration)")]
    public float RotationSpeed = 10;
    Rigidbody2D myRb;

    [Tooltip("Drag the laser prefab here to use")]
    public GameObject Laser;

    public float Cooldown = 0.2f;
    float Timer = 0;
    public float LaserSpeed = 15;
    public Vector3 Offset1 = new Vector3(.4f, .8f, 0);
    public Vector3 Offset2 = new Vector3(-.4f, .8f, 0);


    FollowingCamera FC;
    public float FireShakeTime = 0.1f;
    public float FireShakeMag = 0.2f;

    //audio things
    AudioSource myAudio;
    public AudioClip LaserSound;

    void Start()
    {
        myRb = this.GetComponent<Rigidbody2D>();
        FC = FindObjectOfType<FollowingCamera>();
        myAudio = GetComponent<AudioSource>();
    }

    //fixed update runs once per physics loop
    private void FixedUpdate()
    {
        //grab the inputs and save
        float forwardVel = Input.GetAxisRaw("Vertical");
        float turn = Input.GetAxisRaw("Horizontal");
        //get the movement vector for the object to use
        Vector3 direction = transform.up * forwardVel;

        /*if (forwardVel > 0 && !myAudio.isPlaying)
        {
            myAudio.Play();
        }
        else if(forwardVel <= 0 && myAudio.isPlaying)
        {
            myAudio.Stop();
        }*/

        //set the force on the up vector
        myRb.AddForce(direction * Speed * Time.fixedDeltaTime);
        //rotate the object
        myRb.AddTorque(-turn * RotationSpeed * Time.fixedDeltaTime);
    }





    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Input.GetAxisRaw("Jump") == 1 && Timer >= Cooldown)
        {
            //make laser noise
            myAudio.PlayOneShot(LaserSound);
            //fire objects
            Fire(Offset1);
            Fire(Offset2);
            Timer = 0;
        }
    }

    void Fire(Vector3 offset)
    {
        Vector3 spawnpos = transform.position + transform.rotation * offset;
        GameObject las1 = Instantiate(Laser, spawnpos, transform.rotation);

        las1.GetComponent<Rigidbody2D>().velocity = transform.up * LaserSpeed;

        FC.TriggerShake(FireShakeTime, FireShakeMag);
    }
}

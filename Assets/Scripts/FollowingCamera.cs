using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowingCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("Drag the game object you want the camera to follow into here")]
    public GameObject Target;
    [Tooltip("How snappy the camera is from zero to one"),Range(0,1)]
    public float LerpTVal = 0.5f;


    public float ShakeTime = 0;
    public float ShakeMagnitude = 0;

    public void TriggerShake(float time, float magnitude)
    {
        if(magnitude > ShakeMagnitude)
        {
            ShakeMagnitude = magnitude;
        }
        if(time > ShakeTime)
        {
            ShakeTime = time;
        }
    }
    void Start()
    {
        
    }
    //update is called once per frame update
    private void FixedUpdate()
    {
        
        if (Target != null)
        {
            //calculate the position to aim for
            Vector3 newPos = Target.transform.position;
            newPos.z = transform.position.z;
            //lerp (linearly interpolate towards that point which smooths it)
            transform.position = Vector3.Lerp(transform.position, newPos, LerpTVal);
        }
        if(ShakeTime > 0)
        {
            //decrease shake timer
            ShakeTime -= Time.fixedDeltaTime;
            Vector3 shakeDir = Random.insideUnitCircle;
            transform.position += shakeDir * ShakeMagnitude;
        }
        else
        {
            ShakeMagnitude = 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

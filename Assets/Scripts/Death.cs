using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{

    public UnityEvent OnDeath;
    private AudioSource source;
    public AudioClip DeathNoise;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        OnDeath.AddListener(PlaySound);
    }

    void PlaySound()
    {
        if (DeathNoise != null && source != null)
            source.PlayOneShot(DeathNoise);
    }
    // Update is called once per frame
    void Update()
    {

    }
}

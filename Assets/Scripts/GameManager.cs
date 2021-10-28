using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static int Score = 0;
    private bool amIdead;
    //public static int Health = 5;
    private static GameManager _instance;
    private static GameObject player;

    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(_instance != this)
        {
            Destroy(this);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("guy1");
        amIdead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null && amIdead == false)
        {
            StartCoroutine(DelayStart());
            amIdead = true;
        }
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("endscreen");
    }
}

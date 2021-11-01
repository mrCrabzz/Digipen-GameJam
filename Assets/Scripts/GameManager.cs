using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static bool isHardMode = false;
    public static bool isNormalMode = false;

    public static int Score = 0;
    public static int HighScore = 0;

    public static int HardScore = 0;
    public static int HardHighScore = 0;
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
            print("dead");
        }
        player = GameObject.Find("guy1");
        if (player != null)
        {
            amIdead = false;
        }


    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(3);
        if (Score > HighScore)
        {
            HighScore = Score;
        }
        if (HardScore > HardHighScore)
        {
            HardHighScore = HardScore;
        }
        SceneManager.LoadScene("endscreen");
    }
}

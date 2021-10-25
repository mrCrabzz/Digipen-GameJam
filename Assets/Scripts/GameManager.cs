using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int Score = 0;

    private static GameManager _instance;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

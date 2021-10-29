using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordNormalMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.isNormalMode = true;
        GameManager.isHardMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

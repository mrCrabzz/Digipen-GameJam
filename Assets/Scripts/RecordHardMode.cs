using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordHardMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.isNormalMode = false;
        GameManager.isHardMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

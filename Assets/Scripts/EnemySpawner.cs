using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float interval = 100;
    private float counter = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        counter += 1;

        if (counter >= interval)
        {
            counter = 0;
            int degree = Random.Range(0, 360);
            Instantiate(enemyPrefab, new Vector3(Mathf.Cos(degree)*60f, Mathf.Sin(degree) * 60f, transform.position.z), transform.rotation);

        }
    }

    //circle radius: 60
    //x pos: cosine(degree)*60
    //y pos: sine(degree)*60
}

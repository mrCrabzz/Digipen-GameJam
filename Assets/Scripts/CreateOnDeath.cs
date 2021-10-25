using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOnDeath : MonoBehaviour
{
    [Tooltip("Select the object to spawn when destroyed")]
    public GameObject PrefabToMake;
    public Vector3 OffSet = Vector3.zero;
    public float RandOffSet = 0;


    private void OnDeath()
    {
        Vector3 spawnPos = transform.position + OffSet;
        Vector3 randVect = Random.insideUnitCircle * RandOffSet;
        Instantiate(PrefabToMake, spawnPos + randVect, transform.rotation);


    }


    // Start is called before the first frame update
    void Start()
    {
        Death D = GetComponent<Death>();
        if (D != null)
        {
            D.OnDeath.AddListener(OnDeath);
        }
    }
}

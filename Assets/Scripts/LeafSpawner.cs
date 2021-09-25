using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSpawner : MonoBehaviour
{
    public GameObject leafPrefab;
    private float timer = 0;
    public int freqMin = 0;
    public int freqMax = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            // Spawn new leaf
            //Instantiate(leafPrefab, , Quaternion.identity);
            timer = Random.Range(freqMin, freqMax);
        }
    }
}

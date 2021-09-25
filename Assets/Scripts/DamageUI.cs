using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUI : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Animator>().SetInteger("Direction", Random.Range(1, 4));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

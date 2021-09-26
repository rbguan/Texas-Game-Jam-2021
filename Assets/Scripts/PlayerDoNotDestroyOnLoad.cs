using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoNotDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Do not destroy player on load.");
    }
}

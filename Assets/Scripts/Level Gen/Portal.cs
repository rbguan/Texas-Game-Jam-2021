using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerStats>())
        {
            LevelLoadTransitions levelLoadTransitions = FindObjectOfType<LevelLoadTransitions>();
            levelLoadTransitions.LoadPlayScene();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerStats>())
        {
            //PlayerLevel.Current.level++;
            LevelLoadTransitions levelLoadTransitions = FindObjectOfType<LevelLoadTransitions>();
            levelLoadTransitions.Credits();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private int damage;

    private void OnEnable()
    {
        StartCoroutine(DurationRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = other.GetComponentInParent<PlayerStats>();
        if (playerStats)
        {
            playerStats.CurrentHealth -= damage;
            Debug.Log("Player hit! -1");
            Destroy(gameObject);
        }
    }

    private IEnumerator DurationRoutine()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}

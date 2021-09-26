using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour
{
    public float accelerationTime = 0.2f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float timeLeft;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            gameObject.transform.position += new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f));
            timeLeft += accelerationTime;
        }
    }
}

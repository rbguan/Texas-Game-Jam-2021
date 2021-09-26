using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    [Header("Parts")]
    [SerializeField] private Brain brain;
    [SerializeField] private Hitpoints hitpoints;
    [SerializeField] private Movement movement;
    [SerializeField] private Rigidbody body;

    public Brain Brain
    {
        get
        {
            if (!brain)
                brain = GetComponentInChildren<Brain>();
            return brain;
        }
    }

    public Hitpoints Hitpoints
    {
        get
        { 
            if (!hitpoints)
                hitpoints = GetComponentInChildren<Hitpoints>();
            return hitpoints;
        }
    }

    public Movement Movement
    {
        get
        {
            if (!movement)
                movement = GetComponentInChildren<Movement>();
            return movement;
        }
    }

    public Rigidbody Body
    {
        get
        {
            if (!body)
                body = GetComponentInChildren<Rigidbody>();
            return body;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

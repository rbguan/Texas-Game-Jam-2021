using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    [Header("Parts")]
    [SerializeField] private Brain brain;
    [SerializeField] private Hitpoints hitpoints;
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

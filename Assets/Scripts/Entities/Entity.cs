using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public static List<Entity> entities = new List<Entity>();

    [Header("Parts")]
    [SerializeField] private Animator animator;
    [SerializeField] private Brain brain;
    [SerializeField] private Combat combat;
    [SerializeField] private Hitpoints hitpoints;
    [SerializeField] private Movement movement;
    [SerializeField] private Rigidbody body;

    public Animator Animator
    {
        get
        {
            if (!animator)
                animator = GetComponentInChildren<Animator>();
            return animator;
        }
    }

    public Brain Brain
    {
        get
        {
            if (!brain)
                brain = GetComponentInChildren<Brain>();
            return brain;
        }
    }

    public Combat Combat
    {
        get
        {
            if (!combat)
                combat = GetComponentInChildren<Combat>();
            return combat;
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

    private void OnEnable()
    {
        entities.Add(this);
    }

    private void OnDisable()
    {
        entities.Remove(this);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

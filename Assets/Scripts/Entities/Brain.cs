using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Brain : EntityPart
{
    public State currentState;
    public State chaseState;
    public State attackingState;
    public State stunnedState;

    [SerializeField] private AIDestinationSetter destinationSetter;

    public AIDestinationSetter AIDestinationSetter
    {
        get
        {
            if (!destinationSetter)
                destinationSetter = GetComponentInParent<AIDestinationSetter>();
            return destinationSetter;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        chaseState = new Chase(this);
        attackingState = new Attacking(this);
        stunnedState = new Stunned(this);
    }

    private void Start()
    {
        GoTo(chaseState);
    }

    private void Update()
    {
        if (currentState != null)
            currentState.Update();
    }

    private void FixedUpdate()
    {
        if (currentState != null)
            currentState.FixedUpdate();
    }

    public void GoTo(State state)
    {
        if (currentState != null)
            currentState.End();
        currentState = state;
        if (currentState != null)
            currentState.Start();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : EntityPart
{
    public State currentState;
    public State chaseState;
    public State attackingState;

    protected override void Awake()
    {
        base.Awake();
        chaseState = new Chase(this);
        attackingState = new Attacking(this);
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

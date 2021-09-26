using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public Brain brain;

    public State(Brain brain)
    {
        this.brain = brain;
    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void FixedUpdate()
    {

    }

    public virtual void End()
    {

    }
}

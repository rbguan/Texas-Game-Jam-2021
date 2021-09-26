using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    private const float WAIT_TIME = 1.5f;
    private float waitTime;

    public Idle(Brain brain) : base(brain)
    {

    }

    public override void Start()
    {
        base.Start();
        waitTime = WAIT_TIME;
    }

    public override void Update()
    {
        base.Update();
        if (waitTime > 0)
            waitTime -= Time.deltaTime;
        else
            brain.GoTo(brain.chaseState);
    }
}

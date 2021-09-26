using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunned : State
{
    private const float STUN_DURATION = 1f;

    private float stun;

    public Stunned(Brain brain) : base(brain)
    {

    }
         
    public override void Start()
    {
        base.Start();
        stun = STUN_DURATION;
        brain.parent.Animator.SetTrigger("isZapped");
        
    }

    public override void Update()
    {
        base.Update();
        if (stun >= 0)
            stun -= Time.deltaTime;
        else
            brain.GoTo(brain.chaseState);
    }
}

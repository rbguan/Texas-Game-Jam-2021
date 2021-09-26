using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : State
{
    public Attacking(Brain brain) : base(brain)
    {

    }

    public override void Start()
    {
        base.Start();
        brain.parent.Animator.SetTrigger("goAttack");
    }
}

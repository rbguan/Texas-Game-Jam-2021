using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Chase : State
{
    public Chase(Brain brain) : base(brain)
    {

    }

    public override void Start()
    {
        base.Start();
        brain.AIDestinationSetter.target = PlayerInfo.playerObject.transform;
    }

    public override void End()
    {
        base.End();
        brain.AIDestinationSetter.target = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : State
{
    public Chase(Brain brain) : base(brain)
    {

    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Vector3 directionToPlayer = PlayerInfo.playerObject.transform.position - brain.parent.transform.position;
        Vector2 directionToPlayerClamped = new Vector2(Mathf.Clamp(directionToPlayer.x, -1, 1), Mathf.Clamp(directionToPlayer.z, -1, 1)); 
        brain.parent.Movement.Move(directionToPlayerClamped);
    }
}

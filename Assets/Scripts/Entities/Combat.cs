using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : EntityPart
{
    public Entity player;
    public List<Attack> attacks = new List<Attack>();
    public Attack currentAttack;

    protected override void Awake()
    {
        base.Awake();
        for (int i = attacks.Count - 1; i >= 0; i--)
            attacks[i] = Instantiate(attacks[i]);
    }

    public bool IsInAttackRangeOfPlayer()
    {
        float maxDistance = attacks[0].range;
        float distanceToPlayer = Vector3.Distance(parent.transform.position, PlayerInfo.playerObject.transform.position);
        return distanceToPlayer <= maxDistance;
    }

    public void AttackPlayerWithBestAttack()
    {
        StopAllCoroutines();
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        parent.Brain.GoTo(parent.Brain.attackingState);
        attacks[0].Start();
        yield return attacks[0].Fire(parent.gameObject);
        attacks[0].End();
        parent.Brain.GoTo(parent.Brain.chaseState);
    }
}

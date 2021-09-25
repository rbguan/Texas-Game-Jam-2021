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

    public void AttackPlayerWithBestAttack()
    {

    }
}

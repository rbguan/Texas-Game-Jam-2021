using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitpoints : EntityPart
{
    public int hp;
    public int maxHp;

    protected override void Awake()
    {
        base.Awake();
        hp = maxHp;
    }

    public void ModifyHp(int amount)
    {
        hp += amount;
        if (hp <= 0)
            parent.Destroy();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class AttackEvent
{
    public float delay;
    public GameObject projectilePrefab;
    public float speed;

    public void Fire(GameObject parent)
    {
        GameObject projectile = Object.Instantiate(projectilePrefab, parent.transform.position, Quaternion.identity, ParentManager.Temp);
        projectile.transform.LookAt(PlayerInfo.playerObject.transform);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningDamage : MonoBehaviour
{
    [SerializeField] private int damage;

    private List<Entity> damagedEntities = new List<Entity>();

    private void OnTriggerEnter(Collider other)
    {
        Entity entity = other.GetComponentInParent<Entity>();
        if (entity && !damagedEntities.Contains(entity))
        {
            damagedEntities.Add(entity);
            entity.Hitpoints.ModifyHp(-damage);
            entity.Brain.GoTo(entity.Brain.stunnedState);
            DmgUISpawner.Current.showDmg(damage, entity.transform.position);
            Debug.Log("Hit enemy!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack_", menuName = "New Attack")]
public class Attack : ScriptableObject
{
    public float range;
    public List<AttackEvent> attackEvents = new List<AttackEvent>();

    public void Start()
    {

    }

    public IEnumerator Fire(GameObject parent)
    {
        foreach(AttackEvent attackEvent in attackEvents)
        {
            yield return new WaitForSeconds(attackEvent.delay);
            attackEvent.Fire(parent);
        }
    }

    public void End()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack_", menuName = "New Attack")]
public class Attack : ScriptableObject
{
    public float range;
    public AnimationClip animation;
    public List<AttackEvent> attackEvents = new List<AttackEvent>();

    public void Start()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnDeath : EntityPart   
{
    [SerializeField] private GameObject particleObject;

    private void OnDestroy()
    {
        Instantiate(particleObject, transform.position, Quaternion.identity, ParentManager.Temp);
    }
}

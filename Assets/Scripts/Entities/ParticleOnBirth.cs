using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnBirth : EntityPart   
{
    [SerializeField] private GameObject particleObject;

    private void Start()
    {
        Instantiate(particleObject, transform.position, Quaternion.identity, ParentManager.Temp);
    }
}

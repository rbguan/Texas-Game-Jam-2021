using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPart : MonoBehaviour
{
    public Entity parent;

    protected virtual void Awake()
    {
        if (!parent)
            parent = GetComponentInParent<Entity>();
    }
}

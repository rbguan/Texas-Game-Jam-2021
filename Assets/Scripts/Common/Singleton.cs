using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private T current;

    public T Current
    {
        get
        {
            if (!current)
                current = FindObjectOfType<T>();
            return current;
        }
    }

    protected virtual void Awake()
    {
        if (!current)
            current = (T) this;
        else
            Destroy(this);
    }
}

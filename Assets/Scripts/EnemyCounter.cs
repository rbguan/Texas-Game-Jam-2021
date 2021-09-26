using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : Singleton<EnemyCounter>
{
    [SerializeField] private Text text;

    private void Update()
    {
        text.text = Entity.entities.Count.ToString();
    }
}

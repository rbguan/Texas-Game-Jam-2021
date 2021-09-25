using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DmgUISpawner : MonoBehaviour
{
    public GameObject dmgUIprefab;
    public GameObject enemy;

    void showDmg(float damageAmount, Vector3 enemyLoc)
    {
        var dmgui = Instantiate(dmgUIprefab, enemyLoc + new Vector3(0, 2.5f, 0), Quaternion.identity);
        dmgui.transform.Find("Canvas").transform.Find("Dmg").GetComponent<Text>().text = damageAmount.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscSpawner : MonoBehaviour
{
    public GameObject[] billowingObjects;
    private float timer = 0;
    private int currAmount = 0;
    public int maxAmount = 20;
    public int freqMin = 0;
    public int freqMax = 10;

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0 && currAmount < maxAmount)
        {
            // Spawn new leaf
            var spawnLoc = GetRandomPointInsideCollider(gameObject.GetComponent<BoxCollider>());
            var b = Instantiate(billowingObjects[Random.Range(0, billowingObjects.Length)], spawnLoc, Quaternion.identity);
            b.transform.rotation = new Quaternion(Random.Range(1, 360), Random.Range(1, 360), 0, Random.Range(1, 360));
            b.transform.parent = gameObject.transform;
            timer = Random.Range(freqMin, freqMax);
            currAmount += 1;
        }
    }

    private Vector3 GetRandomPointInsideCollider(BoxCollider boxCollider)
    {
        Vector3 extents = boxCollider.size / 2f;
        Vector3 point = new Vector3(
            Random.Range(-extents.x, extents.x),
            Random.Range(-extents.y, extents.y),
            Random.Range(-extents.z, extents.z)
        );

        return boxCollider.transform.TransformPoint(point);
    }
}

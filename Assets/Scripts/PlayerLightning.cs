using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightning : MonoBehaviour
{
    [SerializeField] private GameObject lightningRodPrefab;
    [SerializeField] private Camera myCamera;
    private List<GameObject> lightningRodsSummoned;
    private bool canPlaceRod = true;
    
    void Start()
    {
        lightningRodsSummoned = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(canPlaceRod)
            {
                PlaceRod();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            ResetRods();
        }
    }

    private void PlaceRod()
    {
        if(lightningRodsSummoned.Count == PlayerStats.Current.MaxRods - 1)
        {
            canPlaceRod = false;
        }
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 rodSpawnPosition;
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            rodSpawnPosition = hit.point;
            GameObject newRod = GameObject.Instantiate(lightningRodPrefab, rodSpawnPosition, Quaternion.identity);
            lightningRodsSummoned.Add(newRod);
        }
    }

    private void ResetRods()
    {
        foreach(GameObject rod in lightningRodsSummoned)
        {
            Destroy(rod);
        }
        lightningRodsSummoned.Clear();
        canPlaceRod = true;

    }


}

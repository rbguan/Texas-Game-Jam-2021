using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRaycastLocation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera myCamera;
    [SerializeField] private Transform testSphere;
    // Update is called once per frame
    public Camera MyCamera
    {
        get
        {
            if (!myCamera)
                myCamera = FindObjectOfType<Camera>();
            return myCamera;
        }
    }

    void Update()
    {
        Ray ray = MyCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            testSphere.transform.position = hit.point;
            
            if(hit.collider.gameObject.layer != 8)
            {
                Debug.Log(hit.collider.name);
            }
        }
    }
}

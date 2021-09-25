using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform myTransform;
    [SerializeField] private float mySpeed = 1f;
    private float LeftRight = 0f;
    private float UpDown = 0f;
    
    void Start()
    {
     
    }

    void Update()
    {
        LeftRight = Input.GetAxis("Horizontal");
        UpDown = Input.GetAxis("Vertical");
        Vector3 movement = ((LeftRight * transform.right) + (UpDown * transform.forward))* mySpeed;
        transform.Translate(movement * Time.deltaTime);
    }
}

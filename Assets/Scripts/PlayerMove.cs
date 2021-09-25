using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform myTransform;
    [SerializeField] private float mySpeed = 1f;
    private float LeftRight = 0f;
    private float UpDown = 0f;
    private Rigidbody myRB;
    
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        LeftRight = Input.GetAxis("Horizontal");
        UpDown = Input.GetAxis("Vertical");
    }

    void FixedUpdate() 
    {
        Vector3 movement = ((LeftRight * transform.right) + (UpDown * transform.forward))* mySpeed * Time.deltaTime;
        // myRB.MovePosition(transform.position + (movement * Time.deltaTime));
        myRB.angularVelocity = Vector3.zero;
        Ray ray = new Ray(transform.position, movement);
        RaycastHit hit;
        if (!Physics.Raycast(ray,out hit, movement.magnitude))
        {
            myRB.MovePosition(transform.position + movement);
        }
        else
        {
            Debug.Log("hit");
            myRB.MovePosition(hit.point);
        }
 
    }
    
}

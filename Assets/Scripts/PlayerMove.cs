using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform myTransform;
    [SerializeField] private Transform bugModelTransform;
    [SerializeField] private Animator myAnimator;
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
        float rotation = 0;
        if(LeftRight != 0 || UpDown != 0)
        {
            myAnimator.SetBool("isRunning", true);
            if (LeftRight > 0) { rotation = 90;}
            if (LeftRight < 0) { rotation = -90;}
            if (UpDown < 0) { rotation = 180;}
            if (UpDown >  0) { rotation = 0;}
            if (LeftRight < 0  && UpDown > 0) { rotation = -45;}
            if (LeftRight > 0  && UpDown > 0) { rotation = 45;}
            if (LeftRight < 0  && UpDown < 0) { rotation = -135;}
            if (LeftRight > 0  && UpDown < 0) { rotation = 135;}
            // bugModelTransform.Rotate()\
            // Vector3 rotationDifference = new Vector3(0, rotation, 0) - bugModelTransform.rotation.eulerAngles;
            // bugModelTransform.DORotate(rotationDifference, .05f);
            bugModelTransform.rotation = Quaternion.Euler(0, rotation,0);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
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
            myRB.MovePosition(hit.point);
        }
 
    }
    
}

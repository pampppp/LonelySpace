using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Animator animator;
    Vector3 dirPos;
    Vector3 dirRot;
    public GameObject target;
    public GameObject cam;

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // 
        animator.GetParameter(3).defaultBool = true;


    }

    public void Locomotion(Rigidbody rb, Vector3 direction, float moveSpeed)
    {
        if (GetComponent<Player>().myStatus == Player.locomotionStatus.INSPACE)
        {
            rb.useGravity = false;
            dirPos = new Vector3(0, direction.y, 0);
            dirRot = new Vector3(0, 0, direction.x);

            rb.AddRelativeForce(Vector3.up * (moveSpeed * direction.y), ForceMode.Acceleration);
            rb.AddTorque(dirRot * -moveSpeed, ForceMode.Acceleration);
            //cam.transform.LookAt(target.transform);
        }
        else if (GetComponent<Player>().myStatus == Player.locomotionStatus.IN_VESSEL)
        {
            
            GetComponent<Rigidbody>().transform.RotateAround(target.transform.position, transform.forward, direction.x * moveSpeed);
            //cam.transform.RotateAround(target.transform.position, transform.forward, direction.x * moveSpeed);
            animator.GetParameter(0).defaultFloat = direction.x * moveSpeed;
            animator.GetParameter(3).defaultBool = true;


        }
        else if (GetComponent<Player>().myStatus == Player.locomotionStatus.USINGLADDER)
        {
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            //transform.position += new Vector3(0, direction.y * moveSpeed, 0);
            transform.position += transform.up * direction.y * moveSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
  
}

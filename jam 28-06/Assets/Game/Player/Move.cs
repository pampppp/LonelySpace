using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    Vector3 dirPos;
    Vector3 dirRot;
    public GameObject target;

    //fonction deplacement sans gravité
    //fonction deplacement avec gravité
    private void Update()
    {
        // 


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
        }
        else if (GetComponent<Player>().myStatus == Player.locomotionStatus.IN_VESSEL)
        {
            
            GetComponent<Rigidbody>().transform.RotateAround(target.transform.position, transform.forward, direction.x * moveSpeed);

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

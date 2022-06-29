using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private bool inAction = false;
    
    public void UseDoor(GameObject door)
    {
        if (!inAction)
        {
            if (Vector3.Distance(door.GetComponent<Door>().aPoint.transform.position, this.transform.position) > Vector3.Distance(door.GetComponent<Door>().bPoint.transform.position, this.transform.position))
            {
                this.transform.position = door.GetComponent<Door>().aPoint.transform.position;
                this.transform.rotation = door.GetComponent<Door>().aPoint.transform.rotation;
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                CheckIfInSpace(door);
                inAction = true;
                StartCoroutine(ActionCD());
                return;
            }
            else if(Vector3.Distance(door.GetComponent<Door>().bPoint.transform.position, this.transform.position) > Vector3.Distance(door.GetComponent<Door>().aPoint.transform.position, this.transform.position))
            {
                this.transform.position = door.GetComponent<Door>().bPoint.transform.position;
                this.transform.rotation = door.GetComponent<Door>().bPoint.transform.rotation;
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                CheckIfInSpace(door);
                inAction = true;
                StartCoroutine(ActionCD());
                return;
            }
        }
        
    }
    public void UseLadder(GameObject ladder)
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        if (!inAction)
        {
            if (Vector3.Distance(ladder.GetComponent<Ladder>().aPoint.transform.position, this.transform.position) > Vector3.Distance(ladder.GetComponent<Ladder>().bPoint.transform.position, this.transform.position))
            {
                if (GetComponent<Player>().myStatus != Player.locomotionStatus.USINGLADDER)
                    GetComponent<Player>().myStatus = Player.locomotionStatus.USINGLADDER;
                else
                    GetComponent<Player>().myStatus = Player.locomotionStatus.IN_VESSEL;
                Debug.Log("dd");
                this.transform.position = ladder.GetComponent<Ladder>().bPoint.transform.position;
                inAction = true;
                StartCoroutine(ActionCD());
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                return;
            }
            else if (Vector3.Distance(ladder.GetComponent<Ladder>().bPoint.transform.position, this.transform.position) > Vector3.Distance(ladder.GetComponent<Ladder>().aPoint.transform.position, this.transform.position))
            {
                if (GetComponent<Player>().myStatus != Player.locomotionStatus.USINGLADDER)
                    GetComponent<Player>().myStatus = Player.locomotionStatus.USINGLADDER;
                else
                    GetComponent<Player>().myStatus = Player.locomotionStatus.IN_VESSEL;
                this.transform.position = ladder.GetComponent<Ladder>().aPoint.transform.position;
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                inAction = true;
                StartCoroutine(ActionCD());
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                return;
            }
        }
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
    public void CheckIfInSpace(GameObject door)
    {
        if (door.GetComponent<Door>().isSeparateVesselToSpace && GetComponent<Player>().myStatus == Player.locomotionStatus.INSPACE)
        {
            GetComponent<Player>().myStatus = Player.locomotionStatus.IN_VESSEL;
            return;
        }
        else if (door.GetComponent<Door>().isSeparateVesselToSpace && GetComponent<Player>().myStatus == Player.locomotionStatus.IN_VESSEL)
            GetComponent<Player>().myStatus = Player.locomotionStatus.INSPACE;
    }
    IEnumerator ActionCD()
    {
        yield return new WaitForSeconds(.5f);
        inAction = false;
    }
}

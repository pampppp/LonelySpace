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
                CheckIfInSpace(door);
                return;
            }
            else if(Vector3.Distance(door.GetComponent<Door>().bPoint.transform.position, this.transform.position) > Vector3.Distance(door.GetComponent<Door>().aPoint.transform.position, this.transform.position))
            {
                this.transform.position = door.GetComponent<Door>().bPoint.transform.position;
                CheckIfInSpace(door);
                return;
            }

            

            inAction = true;
            StartCoroutine(ActionCD());
        }
        
    }
    public void UseLadder()
    {
        if (!inAction)
        {
            if (GetComponent<Player>().myStatus != Player.locomotionStatus.USINGLADDER)
                GetComponent<Player>().myStatus = Player.locomotionStatus.USINGLADDER;
            else
                GetComponent<Player>().myStatus = Player.locomotionStatus.IN_VESSEL;
            inAction = true;
            StartCoroutine(ActionCD());
        }
            
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

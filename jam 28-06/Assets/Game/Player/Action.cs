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
            if (door.transform.position.x > this.transform.position.x)
                this.transform.position += new Vector3(door.transform.localScale.x + 2, 0, 0);
            else if (door.transform.position.x < this.transform.position.x)
                this.transform.position -= new Vector3(door.transform.localScale.x + 2, 0, 0);

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

    IEnumerator ActionCD()
    {
        yield return new WaitForSeconds(.5f);
        inAction = false;
    }
}

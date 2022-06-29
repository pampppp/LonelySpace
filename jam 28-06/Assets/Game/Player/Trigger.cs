using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Door")
        {
            if (Input.GetAxis("Fire1") != 0)
            {
                GetComponent<Action>().UseDoor(other.gameObject);
            }
        }
        else if (other.tag == "Ladder")
        {
            if (Input.GetAxis("Fire1") != 0)
            {
                GetComponent<Action>().UseLadder();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ladder")
        {
            GetComponent<Player>().myStatus = Player.locomotionStatus.IN_VESSEL;
        }
    }
}

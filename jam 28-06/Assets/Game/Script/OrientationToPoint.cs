using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationToPoint : MonoBehaviour
{
    Player player;
    public GameObject point;
    private void Start()
    {
        player = GetComponentInChildren<Player>();
        OrientationToMidleVessel();
    }
    private void Update()
    {
        OrientationToMidleVessel();
    }
    private void OrientationToMidleVessel()
    {
        
        if (player.myStatus == Player.locomotionStatus.IN_VESSEL)
            this.transform.LookAt(point.transform);

    }
}

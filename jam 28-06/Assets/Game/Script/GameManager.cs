using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum quest : ushort
    {
        UN,
        DEUX,
        TROIS,
        QUATRE,
        CINQ,
        SIX,
        SEPT,
        HUIT,
        NEUF
    }
    public quest avencee;
    private void Start()
    {
        avencee = quest.UN;
    }
    private void Update()
    {
        if (avencee == quest.UN)
        {
            //do code
        }
    }
}

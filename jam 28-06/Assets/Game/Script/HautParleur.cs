using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HautParleur : MonoBehaviour
{
    public GameObject player;
    public AudioClip[] soundList;
    float volumValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().myStatus == Player.locomotionStatus.IN_VESSEL)
        {
            volumValue = Vector3.Distance(this.transform.position.normalized, player.transform.position.normalized);
            this.GetComponent<AudioSource>().volume = -volumValue + 1.5f;
        }
        else if (player.GetComponent<Player>().myStatus == Player.locomotionStatus.INSPACE)
        {
            volumValue = 0;
            this.GetComponent<AudioSource>().volume = 0;
        }
        
    }
}

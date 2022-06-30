using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogue;
    public bool isActivable;
    public AudioClip son;

    public void StartEvent() 
    {
        dialogue.SetActive(true);
        this.GetComponent<AudioSource>().clip = son;
        this.GetComponent<AudioSource>().Play();
    }
    private void Update()
    {
        if (Input.GetAxisRaw("Fire2") != 0)
        {
            dialogue.SetActive(false);
        }
    }
}

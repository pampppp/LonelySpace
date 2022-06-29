using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum locomotionStatus : ushort
    {
        IN_VESSEL,
        INSPACE,
        USINGLADDER
    }
    public locomotionStatus myStatus;
    public float walkSpeed;
    public float ladderSpeed;
    public float propulsionSpeed;


    private float RecalculatedSpeed;
    private Vector3 direction;
    public bool isOutside;
    Move movement;
    Cabble cabble;
    Camera camera;
    Rigidbody rb;
    private void Start()
    {
        GetAllCompenent();
        myStatus = locomotionStatus.IN_VESSEL;
    }
    private void Update()
    {
        MoveInput();
    }
    
    public void MoveInput()
    {
        GetPlayerInput();
        CalculNewSpeed();
        movement.Locomotion(rb, GetPlayerInput(), RecalculatedSpeed);

    }

    private void GetAllCompenent()
    {
        if (this.GetComponent<Move>() != null)
            movement = this.GetComponent<Move>();
        if (this.GetComponent<Cabble>() != null)
            cabble = this.GetComponent<Cabble>();
        if (this.GetComponent<Rigidbody>() != null)
            rb = this.GetComponent<Rigidbody>();
    }
    private Vector3 GetPlayerInput() =>  new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
    private void CalculNewSpeed()
    {
        if (myStatus == locomotionStatus.INSPACE)
            RecalculatedSpeed = propulsionSpeed * Time.deltaTime;
        else if (myStatus == locomotionStatus.IN_VESSEL)
            RecalculatedSpeed = walkSpeed * Time.deltaTime;
        else if (myStatus == locomotionStatus.USINGLADDER)
            RecalculatedSpeed = ladderSpeed * Time.deltaTime;
    }
    
}

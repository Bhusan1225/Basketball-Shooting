using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel 
{
    public float Speed = 12f;
    public float MoveX;
    public float MoveZ;
    public float MovementAmount;
    public bool IsGrounded;
    public Vector3 Velocity;
    public Vector3 MovementDirection;
    public Quaternion RequiredRotation;


    public bool IsWatchdogActivated { get; set; } = false;

}

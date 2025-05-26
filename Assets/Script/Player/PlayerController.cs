using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] float rotSpeed = 600f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    [Header("Cameras")]
    [SerializeField] CameraController playerCameraController;
 
    
 
    public PlayerModel model;

    [Header("Projectile and Projectile Force")]
    ProjectileThrow projectileThrow;

    [SerializeField] Slider throwForceSlider;
    [SerializeField] float sliderscrollSensitivity = 1f;

    private void Start()
    {
        model = new PlayerModel();
        projectileThrow = gameObject.GetComponent<ProjectileThrow>();
        throwForceSlider.value = projectileThrow.GetThrowForce();
        throwForceSlider.onValueChanged.AddListener(UpdateThrowForce);
    }

    private void Update()
    {
        HandleMovement();

        HandleBallThrow();
        HandleBallThrowingForce();
    }

    private void HandleBallThrowingForce()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            throwForceSlider.value = Mathf.Min(throwForceSlider.value + sliderscrollSensitivity, throwForceSlider.maxValue);
        }

        if (Input.GetKey(KeyCode.E))
        {
            throwForceSlider.value = Mathf.Max(throwForceSlider.value - sliderscrollSensitivity, throwForceSlider.minValue);
        }
    }

    void UpdateThrowForce(float newValue)
    {
        projectileThrow.SetThrowForce(newValue);
       
    }

    private void HandleBallThrow()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            projectileThrow.ThrowBasketBall();
        }
    }

    void HandleMovement()
    {
        // Ground Check
        model.IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (model.IsGrounded && model.Velocity.y < 0)
            model.Velocity.y = -5f;

        // Input
        model.MoveX = Input.GetAxisRaw("Horizontal");
        model.MoveZ = Input.GetAxisRaw("Vertical");
        model.MovementAmount = Mathf.Clamp01(Mathf.Abs(model.MoveX) + Mathf.Abs(model.MoveZ));
        var movementInput = new Vector3(model.MoveX, 0, model.MoveZ).normalized;

        model.MovementDirection = playerCameraController.flatRoation * movementInput;


        if (model.MovementAmount > 0)
        {
            transform.position += model.MovementDirection * model.Speed * Time.deltaTime;
            model.RequiredRotation = Quaternion.LookRotation(model.MovementDirection);
        }

        // Rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, model.RequiredRotation, rotSpeed * Time.deltaTime);
    }

   
}

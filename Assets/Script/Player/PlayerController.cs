using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] float rotSpeed = 600f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    [Header("Cameras")]
    [SerializeField] CameraController playerCameraController;
 
    [Header("Animators")]
    //[SerializeField] Animator playerAnimator;
 
    public PlayerModel model;

    private void Start()
    {
        model = new PlayerModel();
        
    }

    private void Update()
    {
        handleMovement();
        handleCameraView();
    }

    void handleMovement()
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

    void handleCameraView()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //GameService.Instance.UIService.ActivateCamaraViewUI(true);
        }
        else if ( Input.GetKeyDown(KeyCode.V))
        {
            //GameService.Instance.UIService.ActivateCamaraViewUI(false);
        }

    }
}

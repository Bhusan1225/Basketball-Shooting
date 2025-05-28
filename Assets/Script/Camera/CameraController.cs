using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// This script makes the camera follow the target here the player is the target. 
    /// </summary>
    [SerializeField] Transform target;
    [SerializeField] float cameraGap = 2f;          // you can adjust the the offset of the camera(gap between the target and player)
    [SerializeField] float cameraHeight = 1f;       // you can adjust the the height of the camera
    float rotX;
    float rotY;

    [SerializeField] float minVarAngle = -45f;      // clamp the camera rotation
    [SerializeField] float maxVarAngle = 45f;       // clamp the camera rotation
    [SerializeField] internal bool isThirdPersonActive; // set the camera to first person or third person

    void Start()
    {
        isThirdPersonActive = true;
    }

    // Update is called once per frame
    void Update()
    {

        rotX += Input.GetAxis("Mouse Y");
        rotX = Mathf.Clamp(rotX, minVarAngle, maxVarAngle);
        rotY += Input.GetAxis("Mouse X");

        if (isThirdPersonActive)
        {
            thirdPerson();
        }
        else
        {
            firstPerson();
        }
    }
    public void thirdPerson()
    {
        var targetRotation = Quaternion.Euler(rotX, rotY, 0);

        transform.position = target.position - targetRotation * new Vector3(0f, cameraHeight, cameraGap);
        transform.rotation = targetRotation;
    }

    public void firstPerson()
    {
        var targetRotation = Quaternion.Euler(rotX, rotY, 0);

        Vector3 targetPosition = target.position;

        transform.position = targetPosition - targetRotation * new Vector3(0f, -1.4f, 0f);
        transform.rotation = targetRotation;

        target.rotation = targetRotation;
    }
    public Quaternion flatRoation => Quaternion.Euler(0, rotY, 0);
}

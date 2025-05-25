using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float cameraGap = 2f;
    [SerializeField] float cameraHeight = 1f;

    float rotX;
    float rotY;

    [SerializeField] float minVarAngle = -45f;
    [SerializeField] float maxVarAngle = 45f;
    [SerializeField] internal bool isThirdPersonActive;

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

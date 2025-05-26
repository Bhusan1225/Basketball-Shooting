using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TrajectoryPredictor))]
public class ProjectileThrow : MonoBehaviour
{
 
    TrajectoryPredictor trajectoryPredictor;

    [SerializeField]
    Rigidbody objectToThrow;

    [SerializeField]
    Transform startPosition;

    [SerializeField, Range(0.0f, 50.0f)]
    float throwForce;


    private void OnEnable()
    {
        trajectoryPredictor = GetComponent<TrajectoryPredictor>();

        if (startPosition == null) 
        {
            startPosition = this.transform;
        }
    }

    private void Update()
    {
        Predict();
    }

    void Predict()
    {
        trajectoryPredictor.PredictTrajectory(ProjectileData());
    }

    ProjectileProperties ProjectileData()
    {
        ProjectileProperties properties = new ProjectileProperties();
        Rigidbody rb = objectToThrow.GetComponent<Rigidbody>();

        properties.direction = startPosition.forward;
        properties.initialPosition = startPosition.position;
        properties.initialSpeed = throwForce;
        properties.mass = rb.mass;
        properties.drag = rb.drag;

        return properties;
    }

    public void ThrowBasketBall()
    {
        Rigidbody thrownObject = Instantiate(objectToThrow, startPosition.position, Quaternion.identity);
        thrownObject.AddForce(startPosition.forward * throwForce, ForceMode.Impulse);
    }

    public float GetThrowForce()
    {
        return throwForce;
    }

    public void SetThrowForce(float updateThrowForce)
    {
       throwForce = updateThrowForce;
        return;
    }




}

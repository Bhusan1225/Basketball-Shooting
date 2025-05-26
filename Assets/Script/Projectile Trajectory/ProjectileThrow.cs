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
    float force;


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
        
    }

    void Predict()
    {
        //trajectoryPredictor.PredictTrajectory(ProjectileData());
    }

    ProjectileProperties ProjectileData()

    {
        ProjectileProperties properties = new ProjectileProperties();
        Rigidbody r = objectToThrow.GetComponent<Rigidbody>();

        properties.direction = startPosition.forward;
        properties.initialPosition = startPosition.position;
        properties.initialSpeed = force;
        properties.mass = r.mass;
        properties.drag = r.drag;

        return properties;

    }







}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballController : MonoBehaviour
{

    [SerializeField] GameObject basketball;
    [SerializeField] GameObject playerCamera;

    [SerializeField] float ballDistance = 2f;
    [SerializeField] float ballThrowingForce = 5f;

    [SerializeField] bool holdingBall = true;
    // Start is called before the first frame update
    void Start()
    {
        basketball.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingBall)
        {
            basketball.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;
        }
        if (Input.GetMouseButtonDown(0))
        {
            holdingBall = false;
            basketball.GetComponent <Rigidbody>().useGravity = true;
            basketball.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * ballThrowingForce);
        }
        
    }

    public bool getHoldingBall()
    {
        return holdingBall;
    }
}

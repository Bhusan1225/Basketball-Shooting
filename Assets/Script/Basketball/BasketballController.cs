using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballController : MonoBehaviour
{

    [SerializeField] GameObject basketball;
    [SerializeField] GameObject playerCamera;

    [SerializeField] float ballDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        basketball.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        basketball .transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;
    }
}

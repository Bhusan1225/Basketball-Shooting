using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] BasketballController basketballController;
    [SerializeField] float resetTimer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (basketballController.getHoldingBall() == false) 
        { 
        
                resetTimer -= Time.deltaTime;
        }
        if (resetTimer <= 0) 
        {
            SceneManager.LoadScene("Game");
        }
    }
}

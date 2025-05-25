using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView 
{
    private Animator playerAnimator;
    private Animator dogAnimator;

    public PlayerView(Animator playerAnim, Animator dogAnim)
    {
        playerAnimator = playerAnim;
        dogAnimator = dogAnim;
    }

   
}

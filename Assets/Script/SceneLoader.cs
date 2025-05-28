using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour  
{

    /// <summary>
    /// This scripts manages the scene loading through their index number. And use the button event system here.
    /// </summary>
    

    [Header("Sceneloader Index")]
    [SerializeField] int lobbySceneIndex;
    [SerializeField] int practiceZoneSceneIndex;
    [SerializeField] int playZoneSceneIndex;
    [SerializeField] int arcadeChallengeSceneIndex;

  
    public void LoadPracticeZone()
    {
        SceneManager.LoadScene(practiceZoneSceneIndex);
    }

    public void LoadPlayZone()
    {
        SceneManager.LoadScene(playZoneSceneIndex);
    }

    public void LoadLobby()
    {
        SceneManager.LoadScene(lobbySceneIndex);
    }

    public void LoadArcadeChallenge()
    {
        SceneManager.LoadScene(arcadeChallengeSceneIndex);
    }

}

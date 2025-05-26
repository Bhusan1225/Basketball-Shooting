using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public static SceneLoader Instance { get; private set; }

    [SerializeField] int practiceZoneSceneIndex;
    [SerializeField] int playZoneSceneIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void LoadPracticeZone()
    {
        SceneManager.LoadScene(practiceZoneSceneIndex);
    }

    public void LoadPlayZone()
    {
        SceneManager.LoadScene(playZoneSceneIndex);
    }

}

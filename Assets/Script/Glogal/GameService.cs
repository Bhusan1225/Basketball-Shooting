using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [Header("UI service")]
    [SerializeField]
    private UIServices uiService;
    public UIServices UIService => uiService; //linked the UI service for global use

    public SoundService SoundService { get; private set; } //linked the Sound service for global use


    //Sound Referneces:
    [SerializeField] private SoundScriptable soundScriptables;
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioSource BGSource;

    // Start is called before the first frame update
    void Start()
    {
        SoundService = new SoundService(soundScriptables, SFXSource, BGSource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [Header("UI service")]
    [SerializeField]
    private UIServices uiService;
    public UIServices UIService => uiService; //linked the UI service for global use

    
    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

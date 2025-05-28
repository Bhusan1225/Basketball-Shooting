using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{

    /// <summary>
    /// This scripts will makes the services centerlize, now there is only one service but in future when services will increase it will be helpful
    /// 
    /// </summary>
    [Header("UI service")]
    [SerializeField]
    private UIServices uiService;
    public UIServices UIService => uiService; //Linked the UI service for global use

    
}

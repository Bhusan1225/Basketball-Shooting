using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
{
    /// <summary>
    /// This is generic singleton for building centerlize system (service locator - game service) 
    /// </summary>
    private static T instance;
    public static T Instance
    {
        get { return instance; }
    }
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Debug.LogError($"Singleton of {typeof(T)} is trying to create a second instance. Destroying duplicate.");
            Destroy(this.gameObject);
        }
    }
}

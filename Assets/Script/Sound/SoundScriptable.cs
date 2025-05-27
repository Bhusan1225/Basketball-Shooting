using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "SoundScriptableObject", menuName = "ScriptableObjects/SoundSO")]
public class SoundScriptable : ScriptableObject
{
    public Sounds[] audioList;
}

[Serializable]
public struct Sounds
{
    public SoundType soundType;
    public AudioClip audio;
}

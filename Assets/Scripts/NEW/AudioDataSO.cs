using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NEW { 
[CreateAssetMenu(fileName = "AudioData", menuName = "PlayerData/Audio")]
public class AudioDataSO : ScriptableObject
{
    [Header("Player audio")]
    public AudioClip damagePlayer;
    public AudioClip takeBaseBonus;
    public AudioClip takeBonusSpeed;
    public AudioClip timer;
    public AudioClip fonMusic;

    [Space(5)]
    [Header("Bombs audio")]
    public AudioClip explosion;

    [Space(5)]
    public AudioClip gameOwer;
    public AudioClip gameWin;
    public AudioClip levelTransit;

    [Header("Enemy audio")]
    public AudioClip dudicIdle;
    public AudioClip slizenIdle;
}
}
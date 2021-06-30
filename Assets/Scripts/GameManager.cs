using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentCountEnemy { get; private set; }

    private void Awake()
    {
        if(instance != null) { Debug.LogError("Instance!!!");}

        instance = this;
    }

    


}

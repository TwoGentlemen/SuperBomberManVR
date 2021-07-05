using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeBomb
{
    defaultBomb = 0,
    clockBomb = 1
}

[System.Serializable]
public struct Bomb
{
    public GameObject prefabBomb;
    public TypeBomb typeBomb;
}

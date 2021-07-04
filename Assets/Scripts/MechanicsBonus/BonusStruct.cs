using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Bonus
{
    [Tooltip("Название бонуса")]
    public string name;
    [Tooltip("Префаб бонуса, который появится на сцене")]
    public GameObject prefab;
    [Tooltip("Вероятность выпадения бонуса от 1% до 100%")]
    [Range(1,100)]
    public int dropProbability;


}

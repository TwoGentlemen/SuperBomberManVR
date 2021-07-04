using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Bonus
{
    [Tooltip("�������� ������")]
    public string name;
    [Tooltip("������ ������, ������� �������� �� �����")]
    public GameObject prefab;
    [Tooltip("����������� ��������� ������ �� 1% �� 100%")]
    [Range(1,100)]
    public int dropProbability;


}

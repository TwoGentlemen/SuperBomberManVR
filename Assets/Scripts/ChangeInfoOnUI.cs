using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeInfoOnUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCountBomb;

    private void Start()
    {
        GameManager.instance.spawnBomb.changeValueBombEvent += SpawnBomb_changeValueBombEvent;
    }

    private void SpawnBomb_changeValueBombEvent(int _countBomb)
    {
        textCountBomb.text = _countBomb+"x";
    }

    private void OnDestroy()
    {
        GameManager.instance.spawnBomb.changeValueBombEvent -= SpawnBomb_changeValueBombEvent;
    }
}

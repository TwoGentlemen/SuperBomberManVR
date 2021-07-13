using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeInfoOnUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCountBomb;
    [SerializeField] private TextMeshProUGUI textRadius;

    private void Start()
    {
        GameManager.instance.SpawnBomb.changeValueBombEvent += SpawnBomb_changeValueBombEvent;
        SpawnBomb_changeValueBombEvent(GameManager.instance.PlayerStats.countBomb);

        GridManager.instance.onChageRadiusExplosionEvent += Instance_onChageRadiusExplosionEvent;
    }

    private void Instance_onChageRadiusExplosionEvent(int radius)
    {
        textRadius.text = radius+"x";
    }

    private void SpawnBomb_changeValueBombEvent(int _countBomb)
    {
        textCountBomb.text = _countBomb+"x";
    }

    private void OnDestroy()
    {
        GameManager.instance.SpawnBomb.changeValueBombEvent -= SpawnBomb_changeValueBombEvent;
    }
}

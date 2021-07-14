using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeInfoOnUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCountBomb;
    [SerializeField] private TextMeshProUGUI textRadius;
    [SerializeField] private TextMeshProUGUI textAddSpeed;

    private void Start()
    {
        GameManager.instance.SpawnBomb.changeValueBombEvent += SpawnBomb_changeValueBombEvent;
        SpawnBomb_changeValueBombEvent(GameManager.instance.PlayerStats.countBomb);

        GameManager.instance.PlayerControll.onChangeCountRollerEvent += PlayerControll_onChangeCountRollerEvent;
        PlayerControll_onChangeCountRollerEvent(GameManager.instance.PlayerStats.countRoller);

        GridManager.instance.onChageRadiusExplosionEvent += Instance_onChageRadiusExplosionEvent;
        Instance_onChageRadiusExplosionEvent(GameManager.instance.PlayerStats.radiusBomb);
    }

    private void PlayerControll_onChangeCountRollerEvent(int countRoller)
    {
        textAddSpeed.text = countRoller+"x";
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
        GameManager.instance.PlayerControll.onChangeCountRollerEvent-=PlayerControll_onChangeCountRollerEvent;
        GridManager.instance.onChageRadiusExplosionEvent-=Instance_onChageRadiusExplosionEvent;
    }
}

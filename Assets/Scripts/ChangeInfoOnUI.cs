using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NEW;
public class ChangeInfoOnUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCountBomb;
    [SerializeField] private TextMeshProUGUI textRadius;
    [SerializeField] private TextMeshProUGUI textAddSpeed;

    private void Awake()
    {
        if (Player.instanstance == null) { Debug.LogError("Not player!"); }

        //Subscribe events
        Player.instanstance.changeCountBombAction += ChangeCountBombAction;
        Player.instanstance.changeCountRollerAction += ChangeCountRollerAction;
        Player.instanstance.changeRadiusExplosionAction += ChageRadiusExplosionAction;
    }
    private void Start()
    {
       
    }

    private void ChangeCountRollerAction(int countRoller)
    {
        textAddSpeed.text = countRoller+"x";
    }

    private void ChageRadiusExplosionAction(int radius)
    {
        textRadius.text = radius+"x";
    }

    private void ChangeCountBombAction(int _countBomb)
    {
        textCountBomb.text = _countBomb+"x";
    }

    private void OnDestroy()
    {
        Player.instanstance.changeCountBombAction -= ChangeCountBombAction;
        Player.instanstance.changeCountRollerAction -= ChangeCountRollerAction;
        Player.instanstance.changeRadiusExplosionAction -= ChageRadiusExplosionAction;
    }
}

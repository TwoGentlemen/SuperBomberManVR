using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NEW;
public class ChangeInfoOnUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textQuantityBomb;
    [SerializeField] private TextMeshProUGUI textRadius;
    [SerializeField] private TextMeshProUGUI textQuantityAcceleration;
    [Space(10)]
    [SerializeField] private Text textQuantityEnemy;

    private void Awake()
    {
       
       
    }
    private void OnEnable()
    {
       
    }

    private void Start()
    {
        if (Player.instanstance == null) { Debug.LogError("Not player!"); }
        if(GameManager.instance == null) { Debug.LogError("Not GameManager");}

        //Subscribe events
        Player.instanstance.changeCountBombAction += ChangeQuantityBombAction;
        Player.instanstance.changeCountRollerAction += ChangeQuantityRollerAction;
        Player.instanstance.changeRadiusExplosionAction += ChageRadiusExplosionAction;

        GameManager.instance.changeCountEnemyAction += ChangeQuantityEnemy;
    }

    private void ChangeQuantityEnemy(int value)
    {
       if(textQuantityEnemy == null)
            return;

       textQuantityEnemy.text = value+" Enemy";
    }

    private void ChangeQuantityRollerAction(int countRoller)
    {
        if(textQuantityAcceleration == null)
            return;

        textQuantityAcceleration.text = countRoller+"x";
    }

    private void ChageRadiusExplosionAction(int radius)
    {
        if(textRadius == null)
            return;

        textRadius.text = radius+"x";
    }

    private void ChangeQuantityBombAction(int _countBomb)
    {
        if(textQuantityBomb == null)
            return;

        textQuantityBomb.text = _countBomb+"x";
    }

    private void OnDestroy()
    {
        Player.instanstance.changeCountBombAction -= ChangeQuantityBombAction;
        Player.instanstance.changeCountRollerAction -= ChangeQuantityRollerAction;
        Player.instanstance.changeRadiusExplosionAction -= ChageRadiusExplosionAction;

        GameManager.instance.changeCountEnemyAction -= ChangeQuantityEnemy;
    }
}

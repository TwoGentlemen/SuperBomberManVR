using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonysManager : MonoBehaviour
{

    private Dictionary<float, GameObject> _bonuses;

    [Header("Ссылки на бонусы")]
    [SerializeField] private GameObject bonusSpeed;
    [SerializeField] private GameObject bonusIceCream;
    [SerializeField] private GameObject bonusNotCD;
    [SerializeField] private GameObject bonusNewBomb;
    [SerializeField] private GameObject bonusKickBomb;

    [Header("Настрофки бонусов")]
    [SerializeField] private int _bonusQuantity = 7;

    void Start()
    {
        CreateProbability();
    }

    private void CreateProbability()
    {
        _bonuses = new Dictionary<float, GameObject>();
        _bonuses.Add(10, bonusNewBomb);
        _bonuses.Add(15, bonusKickBomb);
        _bonuses.Add(20, bonusNotCD);
        _bonuses.Add(25, bonusIceCream);
        _bonuses.Add(30, bonusSpeed);
    }

    private void SetBonyses()
    {
        //все клетки с препятствиями
        List<Vector2Int> walls=GridManager.instance.GetObstacle();

        for(int i = 0; i < _bonusQuantity; i++)
        {
            //генерация клетки для бонуса
            System.Random rand = new System.Random();
            int cell = rand.Next(0, walls.Count);

            //генерация бонуса
            GameObject bonus = ChooseBonus();

            //устанавливаем бонус
            GameObject wall = GridManager.instance.GetObjectInCell(walls[cell]);
            wall.GetComponent<BonusDestrWall>().SetBonus(bonus);
        }
    }



    private GameObject ChooseBonus()
    {
        float total = 0;

        foreach (var elem in _bonuses)
        {
            total += elem.Key;
        }

        float randomPoint = Random.value * total;

        foreach(var el in _bonuses)
        {
            if (randomPoint < el.Key)
            {
                return el.Value;
            }
            else
            {
                randomPoint -= el.Key;
            }
        }
        return null;
    }



}

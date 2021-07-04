using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonysManager : MonoBehaviour
{
    [Header("—сылки на бонусы")]
    [SerializeField] private GameObject bonusSpeed;
    [SerializeField] private GameObject bonusNewBomb;
    [SerializeField] private GameObject bonusIceCream;
    [SerializeField] private GameObject bonusAddBomb;
    //[SerializeField] private GameObject bonusKickBomb;

    [Header("Ќастрофки бонусов")]
    [SerializeField] private int _bonusQuantity = 7;

    private Dictionary<float, GameObject> _bonuses;

    void Start()
    {
        //создаетс€ словарь с обьектами и веро€тност€ми
        CreateProbability();
        //расставл€ем бонусы
        SetBonyses();
    }

    private void CreateProbability()
    {
        //не окончательные варианты веро€тности
        _bonuses = new Dictionary<float, GameObject>();
        _bonuses.Add(22, bonusNewBomb);
        _bonuses.Add(15, bonusAddBomb);
        //_bonuses.Add(20, bonusKickBomb);
        _bonuses.Add(21, bonusIceCream);
        _bonuses.Add(16, bonusSpeed);
    }

    private void SetBonyses()
    {
        System.Random rand = new System.Random();
        GameObject bonus, wall;
        List<int> occupiedCells = new List<int>();

        //все клетки с преп€тстви€ми
        List<Vector2Int> walls = GridManager.instance.GetObstacle();

        int cell = rand.Next(0, walls.Count);

        for (int i = 0; i < _bonusQuantity; i++)
        {
            //генераци€ клетки дл€ бонуса
            while (occupiedCells.Contains(cell))
            {
                cell = rand.Next(0, walls.Count);
            }
            occupiedCells.Add(cell);

            //генераци€ бонуса
            bonus = ChooseBonus();

            //устанавливаем бонус
            wall = GridManager.instance.GetObjectInCell(walls[cell]); 

            if(wall == null) { return;}
            wall.GetComponent<BonusDestrWall>().SetBonus(bonus);

            //Debug.Log("бонус на позиции:" + GridManager.instance.GetPosCell(walls[cell]));
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

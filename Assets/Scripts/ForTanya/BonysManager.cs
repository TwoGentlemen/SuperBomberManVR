using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonysManager : MonoBehaviour
{
    private System.Random rand;
    private Dictionary<float, GameObject> _bonuses;

    [SerializeField] private List<Bonus> bonuses;
   
    [Header("Настройки бонусов")]
    [SerializeField] [Range(1,20)] private int _maxBonusQuantity=10;

     private int _bonusQuantity;

    void Start()
    {
        rand = new System.Random();
        _bonusQuantity = rand.Next(3, _maxBonusQuantity+1);
        //создается словарь с обьектами и вероятностями
        CreateProbability();
        //расставляем бонусы
        SetBonyses();
    }

    private void CreateProbability()
    {
        //не окончательные варианты вероятности
        _bonuses = new Dictionary<float, GameObject>();

        foreach (var item in bonuses)
        {
            _bonuses.Add(item.dropProbability,item.prefab);
        }
    }

    private void SetBonyses()
    {

        GameObject bonus, wall;
        List<int> occupiedCells = new List<int>();

        //все клетки с препятствиями
        List<Vector2Int> walls = GridManager.instance.GetObstacle();

        int cell = rand.Next(0, walls.Count);

        for (int i = 0; i < _bonusQuantity; i++)
        {
            //генерация клетки для бонуса
            while (occupiedCells.Contains(cell))
            {
                cell = rand.Next(0, walls.Count);
            }
            occupiedCells.Add(cell);

            //генерация бонуса
            bonus = ChooseBonus();

            //устанавливаем бонус
            wall = GridManager.instance.GetObjectInCell(walls[cell]); 

            if(wall == null) { return;}
            wall.GetComponent<BonusDestrWall>().SetBonus(bonus);

            Debug.Log("бонус на позиции:" + GridManager.instance.GetPosCell(walls[cell]));
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

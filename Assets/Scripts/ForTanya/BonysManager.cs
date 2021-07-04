using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonysManager : MonoBehaviour
{

    private Dictionary<float, GameObject> _bonuses;

    [Header("������ �� ������")]
    [SerializeField] private GameObject bonusSpeed;
    [SerializeField] private GameObject bonusNewBomb;
    [SerializeField] private GameObject bonusIceCream;
    [SerializeField] private GameObject bonusAddBomb;
    //[SerializeField] private GameObject bonusKickBomb;

    [Header("��������� �������")]
    [SerializeField] private int _bonusQuantity = 7;

    void Start()
    {
        //��������� ������� � ��������� � �������������
        CreateProbability();
        //����������� ������
        SetBonyses();
    }

    private void CreateProbability()
    {
        _bonuses = new Dictionary<float, GameObject>();
        _bonuses.Add(10, bonusNewBomb);
        _bonuses.Add(15, bonusAddBomb);
        //_bonuses.Add(20, bonusKickBomb);
        _bonuses.Add(25, bonusIceCream);
        _bonuses.Add(30, bonusSpeed);
    }

    private void SetBonyses()
    {
        GameObject bonus, wall;

        //��� ������ � �������������
        List<Vector2Int> walls=GridManager.instance.GetObstacle();
        
        System.Random rand = new System.Random();
        int cell = rand.Next(0, walls.Count);
        List<int> occupiedCells = new List<int>();


        for (int i = 0; i < _bonusQuantity; i++)
        {
            //��������� ������ ��� ������
            while (occupiedCells.Contains(cell))
            {
                cell = rand.Next(0, walls.Count);
            }
            occupiedCells.Add(cell);
            
            //Debug.Log(cell);

            //��������� ������
            bonus = ChooseBonus();
            //������������� �����
            wall = GridManager.instance.GetObjectInCell(walls[cell]);
            wall.GetComponent<BonusDestrWall>().SetBonus(bonus);

            //Debug.Log("����� �� �������:" + GridManager.instance.GetPosCell(walls[cell]));
        }
    }


    //��������� ������
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

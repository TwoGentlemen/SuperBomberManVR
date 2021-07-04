using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonysManager : MonoBehaviour
{
    private System.Random rand;
    private Dictionary<float, GameObject> _bonuses;
   
    [Header("������ �� ������")]
    [SerializeField] private GameObject bonusSpeed;
    [SerializeField] private GameObject bonusNewBomb;
    [SerializeField] private GameObject bonusIceCream;
    [SerializeField] private GameObject bonusAddBomb;
    //[SerializeField] private GameObject bonusKickBomb;

    [Header("��������� �������")]
    [SerializeField] private int _bonusQuantity;
    [SerializeField] [Range(1,20)] private int _maxBonusQuantity=10;
    [SerializeField] private int speedProbability = 16;
    [SerializeField] private int newBombProbability = 22;
    [SerializeField] private int iceCreamProbability = 21;
    [SerializeField] private int addBombProbability = 15;
    //[SerializeField] private int kickBombProbability = 15;


    void Start()
    {
        rand = new System.Random();
        _bonusQuantity = rand.Next(3, _maxBonusQuantity+1);
        //��������� ������� � ��������� � �������������
        CreateProbability();
        //����������� ������
        SetBonyses();
    }

    private void CreateProbability()
    {
        //�� ������������� �������� �����������
        _bonuses = new Dictionary<float, GameObject>();
        _bonuses.Add(newBombProbability, bonusNewBomb);
        _bonuses.Add(addBombProbability, bonusAddBomb);
        //_bonuses.Add(kickBombProbability, bonusKickBomb);
        _bonuses.Add(iceCreamProbability, bonusIceCream);
        _bonuses.Add(speedProbability, bonusSpeed);
    }

    private void SetBonyses()
    {

        GameObject bonus, wall;
        List<int> occupiedCells = new List<int>();

        //��� ������ � �������������
        List<Vector2Int> walls = GridManager.instance.GetObstacle();

        int cell = rand.Next(0, walls.Count);

        for (int i = 0; i < _bonusQuantity; i++)
        {
            //��������� ������ ��� ������
            while (occupiedCells.Contains(cell))
            {
                cell = rand.Next(0, walls.Count);
            }
            occupiedCells.Add(cell);

            //��������� ������
            bonus = ChooseBonus();

            //������������� �����
            wall = GridManager.instance.GetObjectInCell(walls[cell]); 

            if(wall == null) { return;}
            wall.GetComponent<BonusDestrWall>().SetBonus(bonus);

            Debug.Log("����� �� �������:" + GridManager.instance.GetPosCell(walls[cell]));
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

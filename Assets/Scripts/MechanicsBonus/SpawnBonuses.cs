using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using NEW;
public class SpawnBonuses : MonoBehaviour
{
    private System.Random rand;
    private Dictionary<float, GameObject> _bonuses;

    [SerializeField] private List<Bonus> bonuses;
   
    [Header("????????? ???????")]
    [SerializeField] [Range(1,20)] private int _maxBonusQuantity=10;

     private int _bonusQuantity;

    void Start()
    {
        rand = new System.Random();
        _bonusQuantity = rand.Next(10, _maxBonusQuantity+1);
        //????????? ??????? ? ????????? ? ?????????????
        CreateProbability();
        //??????????? ??????
        SetBonyses();
    }

    private void CreateProbability()
    {
        //?? ????????????? ???????? ???????????
        _bonuses = new Dictionary<float, GameObject>();

        foreach (var item in bonuses)
        {
            _bonuses.Add(item.dropProbability,item.prefab);
        }
    }

    private void SetBonyses()
    {

        GameObject wall;
        List<int> occupiedCells = new List<int>();

        //??? ?????? ? ?????????????
        List<Vector2Int> walls = GridManager.instance.GetObstacle();

        int cell = rand.Next(0, walls.Count);

        for (int i = 0; i < _bonusQuantity; i++)
        {
            //????????? ?????? ??? ??????
            while (occupiedCells.Contains(cell))
            {
                cell = rand.Next(0, walls.Count);
            }
            occupiedCells.Add(cell);


           
            wall = GridManager.instance.GetObjectInCell(walls[cell]); 
            if(wall == null) { return;}
            wall.GetComponent<DestructableWall>().SetObjectInWall(GetRandomBonus());
        }
    }

    private GameObject GetRandomBonus()
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

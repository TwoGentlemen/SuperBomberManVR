using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [Header("ѕараметры наложени€ сетки")]
    [SerializeField] private int step = 2;
    [SerializeField] private Transform gridStart;
    [SerializeField] private Transform gridWith;
    [SerializeField] private Transform gridHight;

    public GameObject point;
    
    
    private List<Vector3> grids = new List<Vector3>();

    private Grid grid;

    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        grid = new Grid(gridStart.position,gridWith.position,gridHight.position,step);

        var obj = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var item in obj)
        {
            grid.ActiveOrNotCell(item.transform.position,false);
        }
        
        var obj2 = GameObject.FindGameObjectsWithTag("DestructableObject");
        foreach (var item in obj2)
        {
            grid.ActiveOrNotCell(item.transform.position,false);
        }

        for (int i = 0; i < grid.countCell_Y; i++)
        for (int j = 0; j < grid.countCell_X; j++)
        {
            if (grid.isEmpty(j, i))
            {
                Instantiate(point,grid.GetPos(j,i), Quaternion.identity);
            }
        }

    }

    public void PlantBomb()
    {
        //определение позиции дл€ бомбы
        Vector3 bombPosition = CreateBombPosition();
        //создание бомбы
        Instantiate(bomb, bombPosition, Quaternion.identity);

    }


    private Vector3 CreateBombPosition()
    {
        ////округл€ю позицию игрока чтобы получилось сделать по клеточкам
        Vector3 playerPosition = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));

        //позици€ бомбы с учетом того, куда смотрит игрок
        Vector3 bombPosition = playerPosition + transform.forward * 2;

        var c = grid.GetIndexCell(bombPosition);

        if (grid.isEmpty(c.x,c.y))
        {
            
            return grid.GetPos(c.x,c.y);
        }
        else
        {
           return Vector3.zero;
        }
    }




}

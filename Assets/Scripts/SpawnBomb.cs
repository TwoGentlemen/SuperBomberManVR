using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [Header("Параметры наложения сетки")]
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
       

        //позиция бомбы с учетом того, куда смотрит игрок
        Vector3 bombPosition = transform.position + transform.forward * (step);

        var indexCelllBomb = grid.GetIndexCell(bombPosition); //Определяем индекс клетки в которой будет находится бомба
        var indexCellPlayer = grid.GetIndexCell(transform.position); //Определяем индекс клетки в которой находится игрок

        if (!grid.isEmpty(indexCelllBomb.x, indexCelllBomb.y)) { return;} //Проверяем клетку на пустоту

        var sum = indexCelllBomb+indexCellPlayer;

        if(sum.x == 2*indexCellPlayer.x || sum.y == 2 * indexCellPlayer.y)
        {
            Instantiate(bomb, grid.GetPos(indexCelllBomb.x,indexCelllBomb.y), Quaternion.identity);
        }
      

    }





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;

    [Header("Параметры наложения сетки")]
    [SerializeField] private int step = 2;
    [SerializeField] private Transform gridStart;
    [SerializeField] private Transform gridWith;
    [SerializeField] private Transform gridHight;

    private Grid grid;
    public GameObject point;



    void Start()
    {
        CreateGrid();
    }



    private void CreateGrid()
    {
        grid = new Grid(gridStart.position, gridWith.position, gridHight.position, step);

        var obj = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var item in obj)
        {
            grid.ActiveOrNotCell(item.transform.position, false);
        }

        var obj2 = GameObject.FindGameObjectsWithTag("DestructableObject");
        foreach (var item in obj2)
        {
            grid.ActiveOrNotCell(item.transform.position, false);
        }

        //for (int i = 0; i < grid.countCell_Y; i++)
        //    for (int j = 0; j < grid.countCell_X; j++)
        //    {
        //        if (grid.isEmpty(j, i))
        //        {
        //            Instantiate(point, grid.GetPos(j, i), Quaternion.identity);
        //        }
        //    }
    }




    public void PlantBomb()
    {
        //определение позиции для бомбы
        Vector3 bombPosition = CreateBombPosition();

        if (bombPosition != Vector3.zero)
        {
            //создание бомбы
            Instantiate(bomb, bombPosition, Quaternion.identity);
            grid.ActiveOrNotCell(bombPosition, false);
        }
        else Debug.Log("Не получается");
    }


    private Vector3 CreateBombPosition()
    {
        Vector2Int playerSell = grid.GetIndexCell(transform.position);
        Vector3 playerPosition = grid.GetPos(playerSell.x, playerSell.y);

        List<Vector3> unavailablePositions = new List<Vector3>();
        unavailablePositions.Add(new Vector3(playerPosition.x+step, playerPosition.y, playerPosition.z+step));
        unavailablePositions.Add(new Vector3(playerPosition.x+step, playerPosition.y, playerPosition.z-step));
        unavailablePositions.Add(new Vector3(playerPosition.x-step, playerPosition.y, playerPosition.z+step));
        unavailablePositions.Add(new Vector3(playerPosition.x-step, playerPosition.y, playerPosition.z-step));

        Vector3 playerForward = transform.position + transform.forward * step;
        Vector2Int bombSell = grid.GetIndexCell(playerForward);
        Vector3 newBombPosition = grid.GetPos(bombSell.x, bombSell.y);

        if (grid.isEmpty(bombSell.x, bombSell.y) && !unavailablePositions.Contains(newBombPosition))
        {
            return newBombPosition;
        }
        else return Vector3.zero;
    }





}

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

    private void Start()
    {
        CreateGrid();
    }
    private void CreateGrid()
    {
        var y = (int)Vector3.Distance(gridHight.position,gridStart.position) / step;
        var x = (int)Vector3.Distance(gridWith.position,gridStart.position) / step;
        y++;
        x++;

        Debug.Log("x = "+x);
        Debug.Log("y = "+y);

        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                var pos = gridStart.position + new Vector3(step * j, gridStart.position.y, -step * i);
                grids.Add(pos);
                Instantiate(point,pos,Quaternion.identity);
            }
        }
    }

    public void PlantBomb()
    {
        //определение позиции для бомбы
        Vector3 bombPosition = CreateBombPosition();
        //создание бомбы
        Instantiate(bomb, bombPosition, Quaternion.identity);

    }


    private Vector3 CreateBombPosition()
    {
        ////округляю позицию игрока чтобы получилось сделать по клеточкам
        Vector3 playerPosition = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));

        //позиция бомбы с учетом того, куда смотрит игрок
        Vector3 bombPosition = playerPosition + transform.forward * 2;
        //исключение диагональных позиций
        //если позиция из списка возможных, оставляем ее
        if (grids.Contains(bombPosition))
        {
            return bombPosition;
        }
        else
        {
            int index=-1;
            float minDistance = float.MaxValue;
            //если позиция неправильная, находим позицию среди возможных, самую близкую к получившийся до этого позиции
            for (int i=0;i<grids.Count;i++)
            {
                float newDistance = Vector3.Distance(grids[i], bombPosition);
                if (newDistance < minDistance)
                {
                    index = i;
                    minDistance = newDistance;
                }
            }

            return grids[index];
        }
    }




}

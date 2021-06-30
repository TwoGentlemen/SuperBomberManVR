using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [SerializeField] private int distance=2;
    [SerializeField] bool isActive=false;
     

    void Update()
    {
        if (isActive)
        {
            PlantBomb();
            Debug.Log(transform.forward);
            isActive = false;
        }
    }


    private void PlantBomb()
    {
        //определение позиции для бомбы
        Vector3 bombPosition = CreateBombPosition();
        //создание бомбы
        Instantiate(bomb, bombPosition, Quaternion.identity);

    }


    private Vector3 CreateBombPosition()
    {
        //округляю позицию игрока чтобы получилось сделать по клеточкам
        Vector3 playerPosition = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        //лист возможных позиций бомбы чтобы исключить позиции по диагонали
        List<Vector3> possiblePositions = new List<Vector3>();
        possiblePositions.Add(new Vector3(playerPosition.x + distance, playerPosition.y, playerPosition.z));
        possiblePositions.Add(new Vector3(playerPosition.x - distance, playerPosition.y, playerPosition.z));
        possiblePositions.Add(new Vector3(playerPosition.x, playerPosition.y, playerPosition.z + distance));
        possiblePositions.Add(new Vector3(playerPosition.x, playerPosition.y, playerPosition.z - 2));
        //позиция бомбы с учетом того, куда смотрит игрок
        Vector3 bombPosition = playerPosition + transform.forward * 2;
        //исключение диагональных позиций
        //если позиция из списка возможных, оставляем ее
        if (possiblePositions.Contains(bombPosition))
        {
            return bombPosition;
        }
        else
        {
            int index=-1;
            float minDistance = float.MaxValue;
            //если позиция неправильная, находим позицию среди возможных, самую близкую к получившийся до этого позиции
            for (int i=0;i<possiblePositions.Count;i++)
            {
                float newDistance = Vector3.Distance(possiblePositions[i], bombPosition);
                if (newDistance < minDistance)
                {
                    index = i;
                    minDistance = newDistance;
                }
            }

            return possiblePositions[index];
        }
    }




}

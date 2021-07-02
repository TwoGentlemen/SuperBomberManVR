using System;
using System.Collections.Generic;
using UnityEngine;


public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    private Cell[,] cells;

    [Header("Параметры наложения сетки")]
    [SerializeField] private int step = 2;
    [SerializeField] private Transform gridStart;
    [SerializeField] private Transform gridWith;
    [SerializeField] private Transform gridHight;
    [SerializeField] private GameObject pointGrid;

    [Tooltip("Тэги статичных объектов, которые являются препядствиями")]
    [SerializeField] private List<string> tagsStaticObject;

    public int countCell_Y => 1 + (int)Vector3.Distance(gridHight.position, gridStart.position) / step; //Кол-во клеток в высоту
    public int countCell_X => 1 + (int)Vector3.Distance(gridWith.position, gridStart.position) / step; //Кол-во клеток в ширину

    private BehaviourExplosion behaviourExplosion = new BehaviourExplosion();

    private void Awake()
    {
        if(instance != null) { Debug.LogError("Instance GridManager");}
        instance = this;

        InicializationCells();
        InicializationStaticObject();
    }

    private void InicializationCells()
    {
        cells = new Cell[countCell_Y + 1, countCell_X + 1]; //Создаем матрицу клеток

            for (int i = 0; i < countCell_Y; i++)
            for (int j = 0; j < countCell_X; j++)
            {
                var pos = gridStart.position + new Vector3(step * j, 0, -step * i);
                var marker = Instantiate(pointGrid, pos, Quaternion.identity);

                cells[i, j] = new Cell(pos, marker);
                    
            }
    }

    private void InicializationStaticObject()
    {
        foreach (var tag in tagsStaticObject)
        {
            var obj = GameObject.FindGameObjectsWithTag(tag);

            foreach (var item in obj)
            {
                SetObjectInCell(item);
            }
        }
    }

    public void SetObjectInCell(GameObject _gameObject)
    {
        var index = GetIndexCell(_gameObject.transform.position);
        cells[index.y,index.x].SetObject(_gameObject);
    }
    public void SetObjectInCell(GameObject _gameObject, Vector2Int index)
    {
        if (index.x < 0 || index.x >= countCell_X || index.y < 0 || index.y >= countCell_Y)
        { Debug.LogWarning("Вы вышли за пределы сетки"); return; }

        cells[index.y, index.x].SetObject(_gameObject);
    }

    public Vector2Int GetIndexCell(Vector3 pos)
    {
        var x = (int)Math.Round((gridStart.position.x - pos.x) / step);
        var y = (int)Math.Round((gridStart.position.z - pos.z) / step);

        x = Math.Abs(x);
        y = Math.Abs(y);
           
        // Debug.Log("x = "+ x +" y = "+y);
        return new Vector2Int(x,y);
    }

    public Vector3 GetPosCell(Vector3 pos)
    {
        var index = GetIndexCell(pos);
        return cells[index.y,index.x].GetPosition();
    }

    public Vector3 GetPosCell(Vector2Int index)
    {
        if (index.x < 0 || index.x >= countCell_X || index.y < 0 || index.y >= countCell_Y)
        { Debug.LogWarning("Вы вышли за пределы сетки"); return Vector3.zero; }

        return cells[index.y, index.x].GetPosition();
    }

    public bool isEmptyCell(Vector2Int index)
    {
        if(index.x<0 || index.x >= countCell_X || index.y < 0 || index.y >= countCell_Y) { return false;}
        return cells[index.y,index.x].isEmptyCell();
    }

    public bool isEmptyCellNotPlayer(Vector2Int index)
    {
        if (index.x < 0 || index.x >= countCell_X || index.y < 0 || index.y >= countCell_Y) { return false; }

        return cells[index.y, index.x].isEmptyCellNotPlayer();
    }

    public GameObject GetObjectInCell(Vector2Int index)
    {
        if (index.x < 0 || index.x >= countCell_X || index.y < 0 || index.y >= countCell_Y)
        { Debug.LogWarning("Вы вышли за пределы сетки"); return null; }

        return cells[index.y,index.x].GetObject();
    }

    public void Explosion(Vector3 bombPos, int radius)
    {
        var index = GetIndexCell(bombPos);

        for (int i = 1; i <= radius; i++)
        {
            if(index.x+i < countCell_X)
            {
                //TODO
                behaviourExplosion.SetBehavioutObject(cells[index.y,index.x+i].GetObject());
            }

            if (index.x - i < countCell_X && index.x - i >=0)
            {
                //TODO
                behaviourExplosion.SetBehavioutObject(cells[index.y, index.x - i].GetObject());
            }

            if (index.y + i < countCell_Y)
            {
                //TODO
                behaviourExplosion.SetBehavioutObject(cells[index.y+i, index.x].GetObject());
            }

            if (index.y - i < countCell_Y && index.y - i >= 0)
            {
                //TODO
                behaviourExplosion.SetBehavioutObject(cells[index.y-i, index.x].GetObject());
            }
        }
    }

    public Vector3 GetRundomNextPoint(Transform currentPos)
    {
        //В начале проверяем можем ли мы двигаться вперед
        var index = GetIndexCell(currentPos.position + currentPos.forward *step);
        if (isEmptyCellNotPlayer(index)) { return GetPosCell(index);}

        //Проверяем можно ли пойти в лево или право (если невозможно вперед)
        //Правая ячейка
        index = GetIndexCell(currentPos.position + currentPos.right * step);
        if (isEmptyCellNotPlayer(index)) { return GetPosCell(index); } 

        //Левая ячейка
        index = GetIndexCell(currentPos.position - currentPos.right * step);
        if (isEmptyCellNotPlayer(index)) { return GetPosCell(index); } 

        //Пробуем развернуться и пойти назад
        index = GetIndexCell(currentPos.position - currentPos.forward * step);
        if (isEmptyCellNotPlayer(index)) { return GetPosCell(index); }

        //Если тупик, то возвращаем текущую позицию
        return currentPos.position;

    }
}


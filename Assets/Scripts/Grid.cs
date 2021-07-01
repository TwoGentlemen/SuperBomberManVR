using UnityEngine;
public class Grid 
{
    class Cell
    {
        private Vector3 _gridPos;
        private bool _isActive;

        public Cell(Vector3 grisPos)
        {
            _gridPos = grisPos;
        }

        public bool GetActive()
        {
            return _isActive;
        }

        public Vector3 GetPosition()
        {
            return _gridPos;
        }

        public void SetActive(bool isActive)
        {
            _isActive = isActive;
        }
    }

    private Cell[,] cells;
    private Vector3 gridStart;
    private Vector3 gridWith;
    private Vector3 gridHight;
    private int step;

    int x = 0; //координаты 
    int y = 0;

    public int countCell_Y => 1 + (int)Vector3.Distance(gridHight, gridStart) / step; //Кол-во клеток в высоту
    public int countCell_X => 1 + (int)Vector3.Distance(gridWith, gridStart) / step; //Кол-во клеток в ширину

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_startPos">Стартовая точка отсчета сетки</param>
    /// <param name="_withPos">Точка правой граници сетки</param>
    /// <param name="_hightPos">Точка нижней граници сетки</param>
    /// <param name="_step">Расстояние между центрами 2-х клеток</param>
    public Grid(Vector3 _startPos, Vector3 _withPos, Vector3 _hightPos, int _step)
    {
        this.gridStart = _startPos;
        this.gridWith = _withPos;
        this.gridHight = _hightPos;
        this.step = _step;

        InicializeGrid(); //Создаем клеточное поле
    }


    private void InicializeGrid()
    {
        cells = new Cell[countCell_Y+1,countCell_X+1]; //Создаем матрицу клеток

        for (int i = 0; i < countCell_Y; i++)
        for (int j = 0; j < countCell_X; j++)
        {
            var pos = gridStart + new Vector3(step * j, gridStart.y, -step * i);
            cells[i,j] = new Cell(pos);
            cells[i,j].SetActive(true);
        }

        Debug.Log("Матрица клеток инициализирована " + countCell_X + " на " + countCell_Y);
    }


    public Vector2Int GetIndexCell(Vector3 posObj)
    {
        float minDist = float.MaxValue;

        int _x = 0;
        int _y = 0;

        for (int y = 0; y < countCell_Y; y++)
        for (int x = 0; x < countCell_X; x++)
        {
            var dis = Vector3.Distance(posObj, cells[y, x].GetPosition());

            if (dis < minDist)
            {
                minDist = dis;
                _x = x;
                _y = y;
            }
        }

        return new Vector2Int(_x,_y);
    }

    public bool isEmpty(int x, int y)
    {

        return cells[y,x].GetActive();
    }

    public void  ActiveOrNotCell(Vector3 posObj, bool isActive)
    {
        var byf = GetIndexCell(posObj);

        Debug.Log("Получен индекс клетки в котором находится объект. y = "+byf.y + " x = "+ byf.x);
        cells[byf.y,byf.x].SetActive(isActive);

    }

    public Vector3 GetPos(int x, int y)
    {
        return cells[y,x].GetPosition();
    }
   
   
}

using UnityEngine;
public class Grid 
{
    class Cell
    {
        private Vector3 _gridPos;
        private bool _isActive;
        private GameObject _gameObj;

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

        public GameObject GetObject()
        {
            return _gameObj;
        }

        public void SetObject(GameObject gameObj)
        {
            _gameObj = gameObj;
        }
    }

    private Cell[,] cells;
    private Vector3 gridStart;
    private Vector3 gridWith;
    private Vector3 gridHight;
    private int step;


    public int countCell_Y => 1 + (int)Vector3.Distance(gridHight, gridStart) / step; //���-�� ������ � ������
    public int countCell_X => 1 + (int)Vector3.Distance(gridWith, gridStart) / step; //���-�� ������ � ������

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_startPos">��������� ����� ������� �����</param>
    /// <param name="_withPos">����� ������ ������� �����</param>
    /// <param name="_hightPos">����� ������ ������� �����</param>
    /// <param name="_step">���������� ����� �������� 2-� ������</param>
    public Grid(Vector3 _startPos, Vector3 _withPos, Vector3 _hightPos, int _step)
    {
        this.gridStart = _startPos;
        this.gridWith = _withPos;
        this.gridHight = _hightPos;
        this.step = _step;

        InicializeGrid(); //������� ��������� ����
    }


    private void InicializeGrid()
    {
        cells = new Cell[countCell_Y+1,countCell_X+1]; //������� ������� ������

        for (int i = 0; i < countCell_Y; i++)
        for (int j = 0; j < countCell_X; j++)
        {
            var pos = gridStart + new Vector3(step * j, 0, -step * i);
            cells[i,j] = new Cell(pos);
            cells[i,j].SetActive(true);
        }

        var obj = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var item in obj)
        {
            ActiveOrNotCell(item.transform.position, false, item);
            //Debug.Log(item.transform.position);
        }

        var obj2 = GameObject.FindGameObjectsWithTag("DestructableObject");
        foreach (var item in obj2)
        {
            ActiveOrNotCell(item.transform.position, false, item);
        }

        //Debug.Log("������� ������ ���������������� " + countCell_X + " �� " + countCell_Y);
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
    public bool isEmpty(Vector3 pos)
    {
        var buf = GetIndexCell(pos);
        return cells[buf.y,buf.x].GetActive();
    }

    public void  ActiveOrNotCell(Vector3 posObj, bool isActive,GameObject wall)
    {
        var byf = GetIndexCell(posObj);

        //Debug.Log("������� ������ ������ � ������� ��������� ������. y = "+byf.y + " x = "+ byf.x);
        cells[byf.y,byf.x].SetActive(isActive);
        cells[byf.y, byf.x].SetObject(wall);
    }


    public Vector3 GetPos(int x, int y)
    {
        return cells[y,x].GetPosition();
    }
   

    public GameObject GetGameObject(int x,int y)
    {
        return cells[y, x].GetObject();
    }
   
}

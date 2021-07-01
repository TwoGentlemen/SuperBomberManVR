using UnityEngine;

public class CreateBomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;

    [Header("��������� ��������� �����")]
    [SerializeField] private int step = 2;
    [SerializeField] private Transform gridStart;
    [SerializeField] private Transform gridWith;
    [SerializeField] private Transform gridHight;

    private Grid grid;
    public GameObject point;



    void Start()
    {
        grid = new Grid(gridStart.position, gridWith.position, gridHight.position, step);
    }


    public void PlantBomb()
    {
        Vector3 bombPosition = transform.position + transform.forward * (step);

        var indexCelllBomb = grid.GetIndexCell(bombPosition); // ������ ������ � ������� ����� ��������� �����
        var indexCellPlayer = grid.GetIndexCell(transform.position); //������ ������ � ������� ��������� �����

        if (!grid.isEmpty(indexCelllBomb.x, indexCelllBomb.y)) { return; } //��������� ������ �� �������

        var sum = indexCelllBomb + indexCellPlayer;

        if (sum.x == 2 * indexCellPlayer.x || sum.y == 2 * indexCellPlayer.y)
        {
            Instantiate(bomb, grid.GetPos(indexCelllBomb.x, indexCelllBomb.y), Quaternion.identity);
        }
    }
}

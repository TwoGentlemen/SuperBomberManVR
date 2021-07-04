using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;

    private float coolDownTime = 5;
    private float coolDownTimer = 0f;
    private int bombQuantity = 0;
    private int bombQuantityInRow = 1;
    private bool isTick = true;

    public void AddBombQuantityInRow()
    {
        bombQuantityInRow++;
    }

    private void Update()
    {

        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

    }


    public void PlantBomb()
    {
        if (coolDownTimer > 0) return;


        Vector3 bombPosition = transform.position + transform.forward * 2; //������� ����� � ������ ����, ���� ������� �����

        var indexCelllBomb = GridManager.instance.GetIndexCell(bombPosition); //���������� ������ ������ � ������� ����� ��������� �����
        var indexCellPlayer = GridManager.instance.GetIndexCell(transform.position); //���������� ������ ������ � ������� ��������� �����

        if (!GridManager.instance.isEmptyCell(indexCelllBomb))
        { Debug.Log("������ ������!"); return; }

        var sum = indexCelllBomb + indexCellPlayer;

        if (sum.x == 2 * indexCellPlayer.x || sum.y == 2 * indexCellPlayer.y)
        {
            var bom = Instantiate(bomb, GridManager.instance.GetPosCell(indexCelllBomb), Quaternion.identity);
            GridManager.instance.SetObjectInCell(bom);
            bombQuantity++;

            if (bombQuantity % bombQuantityInRow == 0)
            {
                coolDownTimer = coolDownTime;
            }         
        }
        else
        {
            Debug.Log("������ ������� �� ���������!");
        }
    }

}
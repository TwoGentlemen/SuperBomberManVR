using System.Collections.Generic;
using UnityEngine;


public class SpawnBomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
   

    public void PlantBomb()
    { 
        Vector3 bombPosition = transform.position + transform.forward * 2; //������� ����� � ������ ����, ���� ������� �����

        var indexCelllBomb = GridManager.instance.GetIndexCell(bombPosition); //���������� ������ ������ � ������� ����� ��������� �����
        var indexCellPlayer = GridManager.instance.GetIndexCell(transform.position); //���������� ������ ������ � ������� ��������� �����

        if (!GridManager.instance.isEmptyCell(indexCelllBomb))
        {Debug.Log("������ ������!"); return;} 

        var sum = indexCelllBomb+indexCellPlayer;

        if(sum.x == 2*indexCellPlayer.x || sum.y == 2 * indexCellPlayer.y)
        {
            var bom = Instantiate(bomb, GridManager.instance.GetPosCell(indexCelllBomb), Quaternion.identity);
            GridManager.instance.SetObjectInCell(bom);
        }
        else
        {
            Debug.Log("������ ������� �� ���������!");
        }
      

    }





}

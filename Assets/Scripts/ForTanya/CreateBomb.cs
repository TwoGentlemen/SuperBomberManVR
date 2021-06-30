using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBomb1 : MonoBehaviour
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


    public void PlantBomb()
    {
        //����������� ������� ��� �����
        Vector3 bombPosition = CreateBombPosition();

        if (bombPosition != Vector3.zero)
        {
            //�������� �����
            Instantiate(bomb, bombPosition, Quaternion.identity);
        }
        else Debug.Log("�� ����������");
    }


    private Vector3 CreateBombPosition()
    {
        //��� �������� �� ������ �� ������
        List<Vector3> unavailablePositions = SetBlocksPositions();
        //�������� ������� ������ ����� ���������� ������� �� ���������
        Vector3 playerPosition = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        //���� ��������� ������� ����� ����� ��������� ������� �� ���������
        List<Vector3> possiblePositions = new List<Vector3>();
        possiblePositions.Add(new Vector3(playerPosition.x + distance, playerPosition.y, playerPosition.z));
        possiblePositions.Add(new Vector3(playerPosition.x - distance, playerPosition.y, playerPosition.z));
        possiblePositions.Add(new Vector3(playerPosition.x, playerPosition.y, playerPosition.z + distance));
        possiblePositions.Add(new Vector3(playerPosition.x, playerPosition.y, playerPosition.z - 2));
        //������� ����� � ������ ����, ���� ������� �����
        Vector3 bombPosition = playerPosition + transform.forward * 2;
        //���������� ������������ �������
        int index = -1;
        float minDistance = float.MaxValue;
        //���� ������� ������������, ������� ������� ����� ���������, ����� ������� � ������������ �� ����� �������
        for (int i = 0; i < possiblePositions.Count; i++)
        {
            float newDistance = Vector3.Distance(possiblePositions[i], bombPosition);
            if (newDistance < minDistance && !unavailablePositions.Contains(possiblePositions[i]))
            {
                index = i;
                minDistance = newDistance;
            }
        }

        if (index == -1) return Vector3.zero;
        Debug.Log("�������:" + possiblePositions[index]);
        return possiblePositions[index];

    }


    private List<Vector3> SetBlocksPositions()
    {
        Vector3 playerPosition = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        Collider[] blocks = Physics.OverlapSphere(playerPosition, distance);

        List<Vector3> blocksPositions = new List<Vector3>();
        foreach (var block in blocks)
        {
            Debug.Log(block.transform.position);
            blocksPositions.Add(new Vector3(Mathf.Round(block.transform.position.x), Mathf.Round(block.transform.position.y), Mathf.Round(block.transform.position.z)));
        }

        return blocksPositions;
    }




}

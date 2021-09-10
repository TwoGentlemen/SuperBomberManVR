using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using NEW;

public class SpawnBomb : MonoBehaviour
{
    [Tooltip("������� ��� �����, ������� ���������� �����")]
    [SerializeField] private TypeBomb currentTypeBomb;
    [SerializeField] private StructBomb[] bombs;

    //--��������� ���������� �� �����������--
    private readonly int coolDownTime = 3; 
    private float timer = 0f;

    private bool isSpawnBomb = true;
    private int countBomb = 1; //���-�� ���� �� �����������
    private int currentCountBomb = 0;//������� ����
    //---------------------------------------

    private GameObject headPlayer;


    private void Start()
    {
        headPlayer = GetComponent<XRRig>().cameraGameObject;

        if(bombs == null) { Debug.LogError("����������� �����");}
        countBomb = Player.instanstance.GetCountBomb();

        Player.instanstance.changeCountBombAction += ChangeCountBombAction;
    }

    private void ChangeCountBombAction(int value)
    {
        countBomb = value;
    }

    private void Update()
    {    
        Timer();
    }

    private void Timer()
    {     
        if(timer >= coolDownTime)
        {
            isSpawnBomb = true;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private GameObject GetCurrentBomb()
    {
        foreach (var item in bombs)
        {
            if(item.typeBomb == currentTypeBomb) { return item.bombPrefab;}
        }

        Debug.LogWarning("����� � ������� ����� �� �������!");
        return bombs[0].bombPrefab;
    }

    public void PlantBomb()
    {
        if (!isSpawnBomb){ return; }


        Vector3 bombPosition = headPlayer.transform.position+ headPlayer.transform.forward * 2; //������� ����� � ������ ����, ���� ������� �����

        var indexCelllBomb = GridManager.instance.GetIndexCell(bombPosition); //���������� ������ ������ � ������� ����� ��������� �����
        var indexCellPlayer = GridManager.instance.GetIndexCell(transform.position); //���������� ������ ������ � ������� ��������� �����

        if (!GridManager.instance.isEmptyCell(indexCelllBomb))
        {            
            Debug.Log("������ ������!"); 
            return; 
        }

        var sum = indexCelllBomb + indexCellPlayer;

        if (!(sum.x == 2 * indexCellPlayer.x || sum.y == 2 * indexCellPlayer.y))
        {
            Debug.Log("������ ������� �� ���������!");
            return;
        }


        var bom = Instantiate(GetCurrentBomb(), GridManager.instance.GetPosCell(indexCelllBomb), new Quaternion(0,transform.rotation.y,0,transform.rotation.w));
        GridManager.instance.SetObjectInCell(bom);

        currentCountBomb++;

        if(currentCountBomb >= countBomb)
        {
            currentCountBomb = 0;
            isSpawnBomb = false;
            timer = 0;
        }
           
        
       
    }

}
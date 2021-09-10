using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using NEW;

public class SpawnBomb : MonoBehaviour
{
    [Tooltip("Текущий тип бомбы, которую использует игрок")]
    [SerializeField] private TypeBomb currentTypeBomb;
    [SerializeField] private StructBomb[] bombs;

    //--Параметры отвечающие за перезарядку--
    private readonly int coolDownTime = 3; 
    private float timer = 0f;

    private bool isSpawnBomb = true;
    private int countBomb = 1; //Кол-во бомб до перезарядки
    private int currentCountBomb = 0;//Счетчик бомб
    //---------------------------------------

    private GameObject headPlayer;


    private void Start()
    {
        headPlayer = GetComponent<XRRig>().cameraGameObject;

        if(bombs == null) { Debug.LogError("Отсутствуют бомбы");}
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

        Debug.LogWarning("Бомба с текущим типом не найдена!");
        return bombs[0].bombPrefab;
    }

    public void PlantBomb()
    {
        if (!isSpawnBomb){ return; }


        Vector3 bombPosition = headPlayer.transform.position+ headPlayer.transform.forward * 2; //позиция бомбы с учетом того, куда смотрит игрок

        var indexCelllBomb = GridManager.instance.GetIndexCell(bombPosition); //Определяем индекс клетки в которой будет находится бомба
        var indexCellPlayer = GridManager.instance.GetIndexCell(transform.position); //Определяем индекс клетки в которой находится игрок

        if (!GridManager.instance.isEmptyCell(indexCelllBomb))
        {            
            Debug.Log("Клетка занята!"); 
            return; 
        }

        var sum = indexCelllBomb + indexCellPlayer;

        if (!(sum.x == 2 * indexCellPlayer.x || sum.y == 2 * indexCellPlayer.y))
        {
            Debug.Log("Нельзя ставить по диагонали!");
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
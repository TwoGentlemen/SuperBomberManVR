using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnBomb : MonoBehaviour
{
    [Tooltip("Текущий тип бомбы, которую использует игрок")]
    [SerializeField] private TypeBomb currentTypeBomb;
    [SerializeField] private Bomb[] bombs;

    //--Параметры отвечающие за перезарядку--
    private float coolDownTime = 5; 
    private float timer = 0f;
    private bool isSpawnBomb = true;
    private int countBomb = 1; //Кол-во бомб до перезарядки
    private int currentCountBomb = 0;//Счетчик бомб
    //---------------------------------------

    public delegate void ChangeValueBomb(int _countBomb);
    public event ChangeValueBomb changeValueBombEvent;

    private void Start()
    {
        if(bombs == null) { Debug.LogError("Отсутствуют бомбы");}
    }
    private void Update()
    {    
        Timer();
    }

    /// <summary>
    /// Увеличивает кол-во бомб до перезарядки
    /// </summary>
    public void AddBombQuantityInRow()
    {
        countBomb++;
        changeValueBombEvent?.Invoke(countBomb);
    }

    /// <summary>
    /// Метод заменяет текущую бомбу на бомбу с выбранным типом
    /// </summary>
    /// <param name="typeBomb"></param>
    public void SetCurrentTypeBomb(TypeBomb typeBomb)
    {
        currentTypeBomb = typeBomb;
        
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
            if(item.typeBomb == currentTypeBomb) { return item.prefabBomb;}
        }

        Debug.LogWarning("Бомба с текущим типом не найдена!");
        return bombs[0].prefabBomb;
    }

    public void PlantBomb()
    {
        if (!isSpawnBomb){ return; }


        Vector3 bombPosition = transform.position + transform.forward * 2; //позиция бомбы с учетом того, куда смотрит игрок

        var indexCelllBomb = GridManager.instance.GetIndexCell(bombPosition); //Определяем индекс клетки в которой будет находится бомба
        var indexCellPlayer = GridManager.instance.GetIndexCell(transform.position); //Определяем индекс клетки в которой находится игрок

        if (!GridManager.instance.isEmptyCell(indexCelllBomb))
        { 
            GameManager.instance.AudioManager.PlayNotSpawnAudio();
            Debug.Log("Клетка занята!"); return; }

        var sum = indexCelllBomb + indexCellPlayer;

        if (sum.x == 2 * indexCellPlayer.x || sum.y == 2 * indexCellPlayer.y)
        {
            GameManager.instance.AudioManager.PlaySpawnBomb();
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
        else
        {
            GameManager.instance.AudioManager.PlayNotSpawnAudio();
            Debug.Log("Нельзя ставить по диагонали!");
        }
    }

}
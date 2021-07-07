using UnityEngine;

public class BonusDestrWall : MonoBehaviour
{

    private GameObject _bonus = null;


    public void Start()
    {
       
    }

    public void SetBonus(GameObject bonus)
    {
        _bonus = bonus;
    }

    public void DestroyWall()
    {

        if (_bonus != null)
        {
            var bon = Instantiate(_bonus, GridManager.instance.GetPosCell(transform.position), Quaternion.identity);
            GridManager.instance.SetObjectInCell(bon, GridManager.instance.GetIndexCell(transform.position));
        }  

        Destroy(gameObject);
    }
}
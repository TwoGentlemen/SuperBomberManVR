using UnityEngine;

public class BonusDestrWall : MonoBehaviour
{

    private GameObject _bonus = null;
    private Vector3 _position;


    public void Start()
    {
       
    }

    public void SetBonus(GameObject bonus)
    {
        _bonus = bonus;
    }

    public void DestroyWall()
    {
        Destroy(gameObject);

        if (_bonus != null)
        {
            Instantiate(_bonus, GridManager.instance.GetPosCell(transform.position), Quaternion.identity);
            GridManager.instance.SetObjectInCell(_bonus, GridManager.instance.GetIndexCell(transform.position));
        }  
    }
}

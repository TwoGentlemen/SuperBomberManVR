using UnityEngine;

public class BonusDestrWall : MonoBehaviour
{

    private GameObject _bonus = null;

    public void SetBonus(GameObject bonus)
    {
        if(bonus == null) { return;}
        _bonus = Instantiate(bonus, GridManager.instance.GetPosCell(transform.position), Quaternion.identity);     
        _bonus.SetActive(false);    
    }

    public void DestroyWall()
    {

        if (_bonus != null)
        {
            _bonus.SetActive(true);
            GridManager.instance.SetObjectInCell(_bonus, GridManager.instance.GetIndexCell(transform.position));
        }  
        Debug.Log("23");
        Destroy(gameObject);
    }
}

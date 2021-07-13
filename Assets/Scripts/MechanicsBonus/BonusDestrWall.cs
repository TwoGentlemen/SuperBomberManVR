using UnityEngine;

public class BonusDestrWall : MonoBehaviour
{

    [SerializeField] GameObject portal;
    private GameObject _bonus = null;


    public void SetBonus(GameObject bonus)
    {
        if(bonus == null || portal != null) { return;}
        _bonus = Instantiate(bonus, GridManager.instance.GetPosCell(transform.position), Quaternion.identity);     
        _bonus.SetActive(false);    
    }

    public void DestroyWall()
    {
        if(portal != null)
        {
            portal.SetActive(true);
            GridManager.instance.SetObjectInCell(portal, GridManager.instance.GetIndexCell(transform.position));
        }
        else
        if (_bonus != null)
        {
            _bonus.SetActive(true);
            GridManager.instance.SetObjectInCell(_bonus, GridManager.instance.GetIndexCell(transform.position));
        }  
        
        Destroy(gameObject);
    }
}

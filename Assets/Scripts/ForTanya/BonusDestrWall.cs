using UnityEngine;

public class BonusDestrWall : MonoBehaviour
{

    private GameObject _bonus = null;
    private Vector3 _position;


    public void Start()
    {
        _position = new Vector3(transform.position.x,transform.position.y+1,transform.position.z);
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
            Instantiate(_bonus, _position, Quaternion.identity);
        }
    }

}

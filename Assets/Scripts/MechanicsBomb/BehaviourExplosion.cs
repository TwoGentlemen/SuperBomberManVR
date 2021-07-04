using UnityEngine;

public class BehaviourExplosion : MonoBehaviour
{
    public void SetBehavioutObject(GameObject obj)
    {
        if (obj == null) { return; }

        switch (obj.tag)
        {
            case "DestructableObject":
                DestructibleObject(obj);
                break;
            case "Bonus":
                DestructibleBonus(obj);
                break;
            case "Player":
                {
                    Debug.Log("����� ����� � ���� ���������!");
                    obj.GetComponent<LifeSystem>().DamagePlayer();
                    break;
                }

            case "Enemy":
                {
                    Debug.Log("������ ����� � ���� ���������!");
                    obj.GetComponent<MobLifeSystem>().AddDamage(1);
                    break;
                }
            default:
                break;
        }
    }

    private void DestructibleObject(GameObject obj)
    {
        GridManager.instance.SetObjectInCell(null, GridManager.instance.GetIndexCell(obj.transform.position));
        obj.GetComponent<BonusDestrWall>().DestroyWall();    
    }

    private void DestructibleBonus(GameObject obj)
    {
        GridManager.instance.SetObjectInCell(null, GridManager.instance.GetIndexCell(obj.transform.position));
        Destroy(obj);
    }
}


using UnityEngine;

    public class BehaviourExplosion : MonoBehaviour
    {

        // ����������� ������ �� ��������� �� �������, ����� ����������

        public void SetBehavioutObject(GameObject obj)
        {
            if(obj == null) { return;}

            switch (obj.tag)
            {
                case "DestructableObject":
                    obj.GetComponent<BonusDestrWall>().DestroyWall();
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
            var index = GridManager.instance.GetIndexCell(obj.transform.position);
            GridManager.instance.SetObjectInCell(null,index);
            Destroy(obj);
        }
    } 


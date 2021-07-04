using UnityEngine;

    public class BehaviourExplosion : MonoBehaviour
    {

        // Скопировала скрипт на переделку на будущее, вдруг пригодится

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
                    Debug.Log("Игрок попал в зону поражения!");
                    obj.GetComponent<LifeSystem>().DamagePlayer();
                    break;
                }

            case "Enemy":
                {
                    Debug.Log("Монстр попал в зону поражения!");
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


using UnityEngine;

public class MobLifeSystem : MonoBehaviour
{
    [SerializeField] [Range(1, 100)] private int healthPoints = 2;
    

    public void AddDamage(int damage)
    {
        healthPoints -= damage;

        if (damage <= 0)
        {
            Destroy(gameObject);
        }
    }

}

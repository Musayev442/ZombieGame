using UnityEngine;

public class Health : MonoBehaviour
{

    private int health = 100;

     public int GetHealth { get => health; }

    public void Damage(int damage)
    {
        if(health<=0)return;

        this.health -= damage;

        if(health<=0)
        {
            print("Die");
            Destroy(gameObject);
        }
    }



}

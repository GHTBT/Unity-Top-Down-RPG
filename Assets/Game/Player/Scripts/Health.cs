using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 20;

    private int Max_Health = 100;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Damage(10);
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
    }

    public void Damage(int amount)
    {

        if (health < 0)
        {
            throw new System.ArgumentOutOfRangeException("Negative Damage smh");
        }

        this.health -= amount;

        if(health <=0)
        {
            Death();
        }
      
    }

    public void Heal(int amount)
    {
        if (health < 0)
        {
            throw new System.ArgumentOutOfRangeException("Negative Heal smh");
        }

        bool Overheal = health + amount > Max_Health;

        if(Overheal)
        {
            health = Max_Health;
        }
        else
        {
            this.health += amount;
        }       
    }

    public void Death()
    {
        Debug.Log("Died");
        Destroy(gameObject);
    }
}
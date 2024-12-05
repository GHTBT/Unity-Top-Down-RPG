using UnityEngine;

public class AttackArea : MonoBehaviour 
{
    private int damage = 5;

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.GetComponent<Health>() != null) 
        {
            Health hp=collider.GetComponent<Health>();
            hp.Damage(damage);
        }
    }
}

using System.Runtime.CompilerServices;
using UnityEngine;

public class SwarmerBehavior : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] 
    private EnemiesData data;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyValue();
    }

    // Update is called once per frame
    void Update()
    {
        Swarm();
    }

    private void SetEnemyValue()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage=data.damage;
        speed=data.speed;
    }

    void Swarm()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
        }       
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.CompareTag("Player"))
        {
            if(collider.GetComponent<Health>()!= null)
            {
                collider.GetComponent<Health>().Damage(damage);
                this.GetComponent<Health>().Damage(1000);
            }
        }    
    }
}

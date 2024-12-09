using Unity.Mathematics;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack = 0.4f;
    private float timer = 0.1f;

    private float delay = 0.1f;

    private float delayTimer = 0.1f;

    [SerializeField] Animator _animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        AttackDirection();

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
        
        if(attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0.1f;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
        attacking = true;
        attackArea.SetActive(attacking);   
    }

    private void AttackDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 PlayerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if(mousePos.x < PlayerScreenPoint.x)
        {
            attackArea.transform.rotation = Quaternion.Euler(0,180,0);
        }
        else
        {
            attackArea.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}

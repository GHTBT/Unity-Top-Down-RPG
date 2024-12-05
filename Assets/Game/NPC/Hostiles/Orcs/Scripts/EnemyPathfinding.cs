using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D _rb;
    private Vector2 _moveDir;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();  
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position+_moveDir*(moveSpeed*Time.fixedDeltaTime));
    }

    public void MoveTo(Vector2 targetPosition)
    {
        _moveDir = targetPosition;
    }
}

using Unity.Mathematics;
using UnityEngine;
[SelectionBase]
public class PlayerController : MonoBehaviour
{
    #region Enums
    private enum Directions { RIGHT, LEFT, UP, DOWN }
    #endregion

    #region Editor Data
    [Header("Movement Attributes")]
    [SerializeField]float _moveSpeed = 120f;

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _spriteRenderer;
    #endregion


    #region Internal Data
    private Vector2 _moveDir = Vector2.zero;
    #endregion

    #region Tick
    private void Update()
    {
        GatherInput();
    }
    private void FixedUpdate()
    {
        MovementUpdate();
        FacingDirection();
    }
    #endregion

    #region Input Logic
    private void GatherInput()
    {
        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("_moveDir.x", _moveDir.x);
        _animator.SetFloat("_moveDir.y", _moveDir.y);
    }
    #endregion

    #region Movement Logic
    private void MovementUpdate()
    {
        _rb.linearVelocity= _moveDir.normalized * _moveSpeed * Time.fixedDeltaTime;  
    }
    #endregion

    private void FacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 PlayerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if(mousePos.x < PlayerScreenPoint.x)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX =false;
        }
    }

}

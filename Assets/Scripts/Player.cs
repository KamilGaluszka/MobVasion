using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private Animator _animator;
    private Vector3 _moveDelta;
    private Vector2 _moveInput;
    public float movementSpeed = 8f;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");
        _animator.SetFloat("Speed", _moveInput.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        _moveDelta = new Vector3(_moveInput.x, _moveInput.y);

        if (_moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (_moveDelta.x < 0)
        {
            transform.localScale = Vector3.one + 2 * Vector3.left;
        }

        transform.Translate(Time.fixedDeltaTime * movementSpeed * _moveDelta);
    }
}

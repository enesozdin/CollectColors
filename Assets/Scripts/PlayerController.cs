using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform groundCheck;
    private Rigidbody2D _rigidbody;

    private DefaultInputActions _defaultPlayerActions;

    private InputAction _moveAction;
    private InputAction _lookAction;

    [SerializeField] float _movementSpeed;
    [SerializeField] float _jumpForce;
    private bool _isGrounded;
    private LayerMask _groundLayerMask;
    public float vertical;
    private void Awake()
    {
        _defaultPlayerActions = new DefaultInputActions();
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundLayerMask = LayerMask.GetMask("Ground");
    }
    private void OnEnable()
    {
        _moveAction = _defaultPlayerActions.Player.Move;
        _moveAction.Enable();
        _lookAction = _defaultPlayerActions.Player.Look;
        _lookAction.Enable();
        _defaultPlayerActions.Player.Jump.performed += OnJump;
        _defaultPlayerActions.Player.Jump.Enable();
    }
    private void OnDisable()
    {
        _moveAction.Disable();
        _lookAction.Disable();
        _defaultPlayerActions.Player.Jump.performed -= OnJump;
        _defaultPlayerActions.Player.Jump.Disable();
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            Debug.Log("jump");
        }

    }
    private void FixedUpdate()
    {
        IsGrounded();
        Movement();

        Vector2 lookDir = _lookAction.ReadValue<Vector2>();
    }
    private void Movement()
    {
        Vector2 inputVector = _moveAction.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, 0f);
        float moveDistance = _movementSpeed * Time.deltaTime;
        transform.position += moveDir * moveDistance;
    }
    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(GetComponent<CapsuleCollider2D>().bounds.min, Vector2.down, GetComponent<CapsuleCollider2D>().bounds.extents.y + 0.05f, _groundLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else { rayColor = Color.red; }
        Debug.DrawRay(GetComponent<CapsuleCollider2D>().bounds.min, Vector2.down * (GetComponent<CapsuleCollider2D>().bounds.extents.y + 0.05f), rayColor);
        return raycastHit.collider != null;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.name == "LadderVisual")
        {
            // _rigidbody.velocity = Vector3.zero;
            Debug.Log("sdfsd");
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 vec2 = new Vector3(0f, _movementSpeed);
                transform.position += vec2 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Vector3 vec2 = new Vector3(0f, -_movementSpeed);
                transform.position += vec2 * Time.deltaTime;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "LadderVisual")
        {
            Debug.Log("AAAAAAAAAAAAA");
        }
    }
}

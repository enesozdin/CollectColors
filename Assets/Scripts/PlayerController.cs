using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private DefaultInputActions defaultPlayerActions;
    private InputAction moveAction;
    private InputAction lookAction;

    [SerializeField] float movementSpeed=10f;
    [SerializeField] float jumpForce=5f;


    private bool isGrounded;
    private LayerMask groundLayerMask;
    private bool facingRight;
    Animator animator;

    public GameObject ghostPrefab;
    private GameObject ghostInstance;
    private bool ghostSpawned = false;
    private Vector2 ghostLastPosition;


    Vector2 stickL;
    Gamepad gamepad;
    private void Awake()
    {
        defaultPlayerActions = new DefaultInputActions();
        rigidbody = GetComponent<Rigidbody2D>();
        groundLayerMask = LayerMask.GetMask("Ground");
    }
    private void Start()
    {
        animator = GetComponent<Animator>();

        ghostLastPosition = transform.position + new Vector3(0, 16);
        gamepad = Gamepad.current;
        
    }
    private void OnEnable()
    {
        moveAction = defaultPlayerActions.Player.Move;
        moveAction.Enable();
        lookAction = defaultPlayerActions.Player.Look;
        lookAction.Enable();
        defaultPlayerActions.Player.Jump.performed += OnJump;
        defaultPlayerActions.Player.Jump.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable();
        defaultPlayerActions.Player.Jump.performed -= OnJump;
        defaultPlayerActions.Player.Jump.Disable();
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        IsGrounded();
        Movement();
        UpdateGhost();
        animator.SetBool("JumpAnimation", !IsGrounded());
        Vector2 lookDir = lookAction.ReadValue<Vector2>();
        if ((gamepad.enabled))
        {
            stickL = gamepad.leftStick.ReadValue();
        }        
    }
    private void Movement()
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        Debug.Log(inputVector);
        //inputVector = inputVector.normalized;
        Vector2 moveDir = new Vector2(inputVector.x, 0f);
        float moveDistance = movementSpeed * Time.deltaTime;
        transform.position += (Vector3)moveDir * moveDistance;

        if (inputVector.x > 0 && facingRight)
        {
            FlipFace();
        }
        else if (inputVector.x < 0 && !facingRight)
        {
            FlipFace();
        }
        if (inputVector.x != 0 && IsGrounded())
        {

            animator.SetBool("RunAnimation", true);
        }
        else
        {
            animator.SetBool("RunAnimation", false);
        }
    }
    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(GetComponent<CapsuleCollider2D>().bounds.center, Vector2.down, GetComponent<CapsuleCollider2D>().bounds.extents.y, groundLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else { rayColor = Color.red; }
        Debug.DrawRay(GetComponent<CapsuleCollider2D>().bounds.center, Vector2.down * (GetComponent<CapsuleCollider2D>().bounds.extents.y), rayColor);
        return raycastHit.collider != null;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.transform.name == "LadderVisual")
        {
            if (Input.GetKey(KeyCode.W) || stickL.y > 0)
            {
                Vector3 vec2 = new Vector3(0f, movementSpeed);
                transform.position += vec2 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S) || stickL.y < 0)
            {
                Vector3 vec2 = new Vector3(0f, -movementSpeed);
                transform.position += vec2 * Time.deltaTime;
            }
        }
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }
    private void UpdateGhost()
    {
        if (!ghostSpawned)
        {
            //ghostInstance = Instantiate(ghostPrefab, lastPosition, Quaternion.identity);
            ghostSpawned = true;
        }

        // Update ghost's position to follow the player's last position
        ghostPrefab.GetComponent<GhostFollow>().SetTargetPosition(ghostLastPosition);

        // Update lastPosition for the next frame
        ghostLastPosition = transform.position;
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Player : MonoBehaviour
{
    public int speed = 3;
    public int jump = 10;
    private InputSystem_Actions controls;
    private Rigidbody2D playerRb;
    private bool isGrounded = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controls = new InputSystem_Actions();
        controls.Player.Enable();
        playerRb = GetComponent<Rigidbody2D>();

        controls.Player.Jump.started += OnJump;
    }

    

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        float xInput = moveInput.x;
        playerRb.linearVelocityX = (speed * xInput);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            playerRb.linearVelocityY = jump;
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

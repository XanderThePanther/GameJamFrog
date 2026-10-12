using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int speed = 3;
    public int jumpForce = 10;
    public int lives = 3;
    public int score = 0;
    private InputSystem_Actions controls;
    private Rigidbody2D playerRb;
    private bool isGrounded = true;
    [SerializeField] private TextMeshPro uiLivesTextElement;
    [SerializeField] private TextMeshPro uiScoreTextElement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controls = new InputSystem_Actions();
        controls.Player.Enable();
        playerRb = GetComponent<Rigidbody2D>();

        controls.Player.Jump.started += OnJump;
        uiLivesTextElement.SetText("Lives: {0}", lives);
        uiScoreTextElement.SetText("Score: {0}", score);
        playerRb.centerOfMass = Vector2.zero;
    }

    

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        float xInput = moveInput.x;
        playerRb.linearVelocityX = (speed * xInput);

        CenterRotation();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            playerRb.linearVelocityY = jumpForce;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fly"))
        {
            score++;
            Destroy(collision.gameObject);
            uiScoreTextElement.SetText("Score: {0}", score);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lives--;
            Destroy(collision.gameObject);
            uiLivesTextElement.SetText("Lives: {0}", lives);
        }
    }

    void CenterRotation()
    {
        Quaternion rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        transform.rotation = rotation;
    }
}

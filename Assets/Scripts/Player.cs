using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int speed = 3;
    public int jumpForce = 10;
    public int health = 3;
    public int score = 0;

    public float timeLimit = .05f;
    private InputSystem_Actions controls;
    private Rigidbody2D playerRb;
    private bool isGrounded = true;
    [SerializeField] private TextMeshPro uiHealthTextElement;
    [SerializeField] private TextMeshPro uiScoreTextElement;
    [SerializeField] private GameObject childObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controls = new InputSystem_Actions();
        controls.Player.Enable();
        playerRb = GetComponent<Rigidbody2D>();

        uiHealthTextElement.SetText("Health: {0}", health);
        uiScoreTextElement.SetText("Score: {0}", score);
        playerRb.centerOfMass = Vector2.zero;
    }

    

    // Update is called once per frame
    void Update()
    {
        Movement();

        Jump();

        CenterRotation();

        Action();

        if(transform.position.y < -5)
        {
            health = 0;
        }
    }

    public void Jump()
    {
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.J)))
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
            health--;
            Destroy(collision.gameObject);
            uiHealthTextElement.SetText("Health: {0}", health);
        }
    }

    void CenterRotation()
    {
        Quaternion rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        transform.rotation = rotation;
    }

    void Movement()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        float xInput = moveInput.x;
        if (xInput > 0 && isGrounded)
        {
            transform.localScale = new Vector3((float)-.6, (float).6, (float).6);
        }
        if (xInput < 0 && isGrounded)
        {
            transform.localScale = new Vector3((float).6, (float).6, (float).6);
        }
        playerRb.linearVelocityX = (speed * xInput);
    }

    void Action()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            childObject.SetActive(true);
            StartCoroutine(ActionTimeLimit());

        }
    }

    private IEnumerator ActionTimeLimit()
    {
        childObject.SetActive(true);

        yield return new WaitForSeconds(timeLimit);

        childObject.SetActive(false);
    }

    void OnDestroy()
    {
        
            controls.Player.Disable();
            controls.Dispose();
    }
}

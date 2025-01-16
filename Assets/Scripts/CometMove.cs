using UnityEngine;

public class CometMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.0f;

    [SerializeField]
    private float moveDuration = 2.0f;

    [SerializeField]
    private bool startMovingLeft = true;

    private Rigidbody2D playerRB = null;
    private float timer = 0.0f; // Timer
    private bool isMovingLeft;
    private Vector3 moveDirection = Vector3.zero;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the initial direction
        isMovingLeft = startMovingLeft;

        SetMoveDirection();
    }

    void Update()
    {
        // Increment timer to track direction change
        timer += Time.deltaTime;

        if (timer >= moveDuration)
        {
            // Switch direction after the set duration
            isMovingLeft = !isMovingLeft;
            SetMoveDirection();
            timer = 0.0f;
        }

        // Apply the movement
        playerRB.linearVelocity = moveDirection * moveSpeed;
    }

    private void SetMoveDirection()
    {
        if (isMovingLeft)
        {
            // Move to the
            moveDirection = new Vector3(-1, 0, 0).normalized;
            RotateSprite(true); // Rotate sprite to face left
        }
        else
        {
            // Move to the right
            moveDirection = new Vector3(1, 0, 0).normalized;
            RotateSprite(false); // Rotate sprite to face right
        }
    }

    private void RotateSprite(bool isLeft)
    {
        if (isLeft)
        {
            // Rotate sprite to face left (clockwise 180 degrees)
            spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        else
        {
            // Rotate sprite to face right (counterclockwise 180 degrees)
            spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, 135);
        }
    }
}

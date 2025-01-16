using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;

    private Rigidbody2D playerRB = null;
    private Vector3 desiredSpeed = Vector3.zero;

    [SerializeField]
    private GameObject alienPrefab = null;

    private float maxMoveLeft = -3.9f;
    private float maxMoveRight = 3.9f;
    private float maxMoveUp = 4.5f;
    private float maxMoveDown = 3.5f;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        desiredSpeed = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            if (playerRB.position.y < maxMoveUp)
            {
                desiredSpeed.y = moveSpeed * Time.deltaTime * 100;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (playerRB.position.y > maxMoveDown)
            {
                desiredSpeed.y = -moveSpeed * Time.deltaTime * 100;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (playerRB.position.x > maxMoveLeft)
            {
                desiredSpeed.x = -moveSpeed * Time.deltaTime * 100;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (playerRB.position.x < maxMoveRight)
            {
                desiredSpeed.x = moveSpeed * Time.deltaTime * 100;
            }
        }

        playerRB.linearVelocityX = desiredSpeed.x;
        playerRB.linearVelocityY = desiredSpeed.y;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnAlien();
        }
    }

    public void SpawnAlien()
    {
        Vector3 spawnPosition = Vector3.zero;
        spawnPosition.x = playerRB.position.x;
        spawnPosition.y = playerRB.position.y - 1.0f;
        GameObject newAlien = Instantiate(alienPrefab, spawnPosition, Quaternion.identity);
    }
}

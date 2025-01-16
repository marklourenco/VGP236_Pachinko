using UnityEngine;

public class GoalScore : MonoBehaviour
{
    [SerializeField]
    private int score = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Alien")
        {
            GameManager.Instance.AddScore(score);
            Destroy(collision.gameObject);
        }
    }
}

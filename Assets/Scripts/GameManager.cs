using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    // Singleton, it gives access to a global manager/container to any file in the program
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }


    [SerializeField]
    private TMP_Text scoreText = null;

    private int score = 0;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            AddScore(0);
        }
    }

    private void Update()
    {

    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "-  " + score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}

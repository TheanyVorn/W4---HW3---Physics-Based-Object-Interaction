using UnityEngine;
using TMPro;  // For TextMeshPro UI (handles your TMP texts)

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI scoreText;     // Now matches your TextMeshPro objects
    public TextMeshProUGUI winText;       // Drag your TMP texts here

    [Header("Flower Settings")]
    public GameObject flowerPrefab;       // Already working from your screenshot

    private int score = 0;
    private int targetScore = 10;

    void Start()
    {
        score = 0;
        UpdateScoreUI();
        if (winText != null)
        {
            winText.gameObject.SetActive(false);  // Hide win text initially
        }

        // Spawn 10 flowers randomly in the field
        if (flowerPrefab != null)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 pos = new Vector3(
                    Random.Range(-8f, 8f), 
                    Random.Range(-3f, 4f), 
                    0
                );
                Instantiate(flowerPrefab, pos, Quaternion.identity);
            }
        }
        else
        {
            Debug.LogWarning("Flower Prefab not assigned!");
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();

        if (score >= targetScore)
        {
            if (winText != null)
            {
                winText.text = "You Won!";
                winText.gameObject.SetActive(true);
            }
            Time.timeScale = 0;  // Pause game
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Flowers Caught: " + score + " / " + targetScore;
        }
    }
}
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

        // Spawn 10 flowers randomly inside the game walls
        if (flowerPrefab != null)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 pos = new Vector3(
                    Random.Range(585f, 613f),   // X: between left wall (584.5) and right wall (613.5)
                    Random.Range(385f, 404f),   // Y: between bottom wall (384) and top wall (405)
                    0
                );
                GameObject flower = Instantiate(flowerPrefab, pos, Quaternion.identity);
                Debug.Log($"Flower {i} spawned at {pos}");
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
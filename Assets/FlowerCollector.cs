using UnityEngine;

public class FlowerCollector : MonoBehaviour
{
    // Reference to GameManager (we'll create next for score)
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();  // Find the score manager
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Detect collision with player (meets OnTriggerEnter requirement)
        if (other.CompareTag("Player"))  // Tag player next
        {
            gameManager.AddScore(1);  // Increment score
            Destroy(gameObject);  // Remove flower
        }
    }
}
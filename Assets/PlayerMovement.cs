using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;  // Reference to Rigidbody2D for applying forces
    public float moveForce = 10f;  // Force strength for movement (customize in Inspector)
    public float torqueForce = 5f; // Optional: Rotation force

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the physics body
    }

    void Update()
    {
        // Get input: Horizontal/Vertical axes (arrow keys or WASD)
        float horizontalInput = Input.GetAxis("Horizontal");  // -1 left, 1 right
        float verticalInput = Input.GetAxis("Vertical");      // -1 down, 1 up

        // Apply force for movement (meets AddForce requirement)
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveForce;
        rb.AddForce(movement);

        // Optional: Apply torque for rotation (meets AddTorque)
        if (horizontalInput != 0)
        {
            rb.AddTorque(-horizontalInput * torqueForce);  // Rotate opposite to direction for fun
        }
    }
}
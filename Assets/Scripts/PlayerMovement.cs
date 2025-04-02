using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{public float moveSpeed = 5f; // Speed of player movement
    public Joystick joystick; // Reference to the joystick UI component
    public Rigidbody rb; // Rigidbody for movement
    public float rotationSpeed = 5f; // Speed of rotation
    private Vector2 lastTouchPosition;
    private Vector3 moveDirection;
    private bool isDragging;
    
    void Start()
    {
        isDragging = false;
    }

    void Update()
    {
        // Get input from the joystick
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        
        // Set movement direction based on the joystick input
        moveDirection = transform.forward * vertical + transform.right * horizontal;

        //Handles rotation of the player
         if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position;
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                float deltaX = touch.position.x - lastTouchPosition.x;
                transform.Rotate(Vector3.up, deltaX * rotationSpeed * Time.deltaTime);
                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
    }
    void FixedUpdate()
    {
        // Apply movement
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    private float velocityY;
    private float mouseX, mouseY;
    private float moveForward, moveRight;

    public float xSensitivity { get; private set; }
    public float ySensitivity { get; private set; }
    public float moveSpeed { get; private set; }
    public float gravity { get; private set; }
    public float jumpSpeed;

    public Camera playerCamera;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        xSensitivity = 5;
        ySensitivity = 5;
        moveSpeed = 5;
        gravity = 9.8f;
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateMouse();
        UpdateMovement();
        UpdateYSpeed();
    }

    // calculates how far the mouse has moved, and rotates the player and camera accordingly
    private void UpdateMouse()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(0, mouseX* xSensitivity, 0));
        playerCamera.transform.Rotate(new Vector3(-mouseY* ySensitivity, 0, 0));
    }

    // calculates whether wasd has been pressed, and moves the player accordingly
    private void UpdateMovement()
    {
        moveForward = Input.GetAxisRaw("Vertical");
        moveRight = Input.GetAxisRaw("Horizontal");

        Vector3 velocity = new Vector3();
        velocity += moveRight * transform.right;
        velocity += moveForward * transform.forward;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocity *= 2;
        }

        cc.SimpleMove(velocity * moveSpeed);
        if (!cc.isGrounded)
        {
            print(cc.isGrounded);
        }
    }

    private void UpdateYSpeed()
    {
        if (Input.GetKey(KeyCode.Space) && cc.isGrounded)
        {
            print("jump");
            velocityY = jumpSpeed;
        }

        else if (cc.isGrounded)
        {
            velocityY = 0;
        }

        velocityY -= gravity * Time.deltaTime;
        cc.Move(new Vector3(0, velocityY, 0) * Time.deltaTime);
    }
}

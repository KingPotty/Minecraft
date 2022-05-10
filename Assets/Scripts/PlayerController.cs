using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float mouseX, mouseY;

    public float xSensitivity, ySensitivity, moveSpeed;
    public Camera playerCamera;

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(0, mouseX * xSensitivity, 0));
        playerCamera.transform.Rotate(new Vector3(- mouseY * ySensitivity, 0, 0));

        Vector3 velocityChange = transform.forward * 100;
        rb.velocity = new Vector3(
            moveSpeed * transform.forward.x,
            moveSpeed * transform.forward.y,
            moveSpeed * transform.forward.z);

        /*if (input.getkey(keycode.w))
        {
            rb.velocity += transform.forward * movespeed;
        }
        else if (input.getkey(keycode.d))
        {
            rb.velocity += transform.right * movespeed;
        }
        else if (input.getkey(keycode.s))
        {
            rb.velocity -= transform.forward * movespeed;
        }
        else if (input.getkey(keycode.a))
        {
            rb.velocity -= transform.right * movespeed;
        }*/

    }
}

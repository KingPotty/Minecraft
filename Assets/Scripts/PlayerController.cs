using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    private float mouseX, mouseY;

    public float xSensitivity, ySensitivity, moveSpeed;
    public Camera playerCamera;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX, mouseY, moveForward, moveRight;
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(0, mouseX * xSensitivity, 0));
        playerCamera.transform.Rotate(new Vector3(- mouseY * ySensitivity, 0, 0));

        moveForward = Input.GetAxis("Vertical");
        moveRight = Input.GetAxis("Horizontal");
        print(moveForward.ToString() + ", " + moveRight.ToString());

        cc.Move(new Vector3(0, moveRight * transform.right.y * moveSpeed, moveForward * transform.forward.z * moveSpeed) * Time.deltaTime);
    }
}

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Mouse sensitivity, adjustable through the Unity inspector
    public Transform playerBody; // Reference to the player body to rotate around

    private float xRotation = 0f; // To keep track of the vertical rotation

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Optional: Lock the cursor to the center of the screen
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamping the rotation to prevent gimbal lock

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
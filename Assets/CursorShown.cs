using UnityEngine;

public class CursorShown : MonoBehaviour
{
    // Set these in the inspector or via script to determine cursor behavior
    public bool cursorVisible = true;
    public CursorLockMode cursorLockMode = CursorLockMode.None;

    void Start()
    {
        // Set cursor visibility
        Cursor.visible = cursorVisible;

        // Set cursor lock state
        Cursor.lockState = cursorLockMode;
    }
}

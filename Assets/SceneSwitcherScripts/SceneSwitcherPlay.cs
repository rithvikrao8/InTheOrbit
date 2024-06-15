using UnityEngine;
using UnityEngine.SceneManagement;

// This script allows switching from the GameScene to the SettingsScene when the 'Esc' key is pressed.
public class SceneSwitcherPlay : MonoBehaviour
{
    void Update()
    {
        // Check if the 'Esc' key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Load the SettingsScene
            SceneManager.LoadScene("Spaceship");
        }
    }
}

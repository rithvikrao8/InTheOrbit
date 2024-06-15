using UnityEngine;
using UnityEngine.SceneManagement;

// This script allows switching from the GameScene to the SettingsScene when the 'Esc' key is pressed.
public class ScebeSwitcherCreditsSceneFinal : MonoBehaviour
{
    void Update()
    {
        // Check if the 'Esc' key is pressed
        if (Input.GetKeyDown(KeyCode.B))
        {
            // Load the SettingsScene
            SceneManager.LoadScene("Main Menu");
        }
    }
}

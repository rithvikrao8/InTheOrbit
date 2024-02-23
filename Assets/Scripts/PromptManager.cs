using UnityEngine;
using UnityEngine.UI; // Include if using UI Text or Buttons
using TMPro; // Uncomment if using TextMeshPro elements

public class PromptManager : MonoBehaviour
{
    //public Text promptText; // Change to public TextMeshProUGUI if using TextMeshPro
    [SerializeField] public TextMeshProUGUI promptText; // Change to public TextMeshProUGUI if using TextMeshPro
    [SerializeField] Canvas promptCanvas;
    public string[] prompts;
    private int currentPromptIndex = 0;

    public void Start()
    {
        prompts = new [] {
        "Welcome to the Forest Biome",
        "Kill enemies to survive",
        }; // Array of prompts to display

        Debug.Log("PromptManager Start() called");
        if(prompts.Length > 0)
        {
            ShowPrompt(currentPromptIndex); // Show the first prompt
        }
    }

    private void ShowPrompt(int index)
    {
        Debug.Log("ShowPrompt called with index: " + index);
        if(index >= 0 && index < prompts.Length)
        {
            promptText.text = prompts[index]; // Update the text element with the current prompt
        }
    }

    public void NextPrompt()
    {
        Debug.Log("NextPrompt called " + currentPromptIndex + " " + prompts.Length);
        if(currentPromptIndex < prompts.Length - 1)
        {
            currentPromptIndex++;
            ShowPrompt(currentPromptIndex);
        }
        else
        {
            promptCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void PreviousPrompt()
    {
        Debug.Log("PreviousPrompt called");
        if(currentPromptIndex > 0)
        {
            currentPromptIndex--;
            ShowPrompt(currentPromptIndex);
        }
        else
        {
            promptCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
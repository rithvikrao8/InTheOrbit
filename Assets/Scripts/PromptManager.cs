using UnityEngine;
using UnityEngine.UI; // Include if using UI Text or Buttons
using TMPro; // Uncomment if using TextMeshPro elements

public class PromptManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI promptText; // Change to public TextMeshProUGUI if using TextMeshPro
    [SerializeField] Canvas promptCanvas;

    public string[] forestprompts = new[] {
    "Welcome to the Forest Biome",
    "Kill forest demons to survive",
    "You have survived the forest biome, now go to the mountain biome",
    };

    public string[] mountainprompts = new[] {
    "Welcome to the mountain Biome",
    "Kill mountain goats to survive",
    };

    public string[] polarprompts = new[] {
    "Welcome to the polar Biome",
    "Kill penguin demons to survive",
    };

    public string[] prompts;
    public string[] status;
    private int currentPromptIndex = 0;

    public enum PromptName
    {
        Forest,
        Mountain,
        Polar
    }

    private PromptName biome;

    public void SetPromptName(PromptName name)
    {
        Debug.Log("PromptManager.SetPromptName() called");
        this.biome = name;
        switch (this.biome)
        {
            case PromptName.Forest:
                prompts = forestprompts;
                break;
            case PromptName.Mountain:
                prompts = mountainprompts;
                break;
            case PromptName.Polar:
                prompts = polarprompts;
                break;
        }
        if (prompts.Length > 0)
        {
            currentPromptIndex = 0;
            ShowPrompt(currentPromptIndex); // Show the first prompt
        }
    }
    public void Start()
    {
        Debug.Log("PromptManager Start() called");
    }

    private void ShowPrompt(int index)
    {
        Debug.Log("ShowPrompt called with index: " + index);
        promptCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        if (index >= 0 && index < prompts.Length)
        {
            promptText.text = prompts[index]; // Update the text element with the current prompt
        }
    }

    public void NextPrompt()
    {
        Debug.Log("NextPrompt called " + currentPromptIndex + " " + prompts.Length);
        if (currentPromptIndex < prompts.Length - 1)
        {
            currentPromptIndex++;
            ShowPrompt(currentPromptIndex);
        }
        else
        {
            promptCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            //reset
            currentPromptIndex = 0;
        }
    }

    public void PreviousPrompt()
    {
        Debug.Log("PreviousPrompt called" + currentPromptIndex + " " + prompts.Length);
        if (currentPromptIndex > 0)
        {
            currentPromptIndex--;
            ShowPrompt(currentPromptIndex);
        }
    }
}
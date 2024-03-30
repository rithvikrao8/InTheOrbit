using UnityEngine;
using UnityEngine.UI; // Include if using UI Text or Buttons
using TMPro; // Uncomment if using TextMeshPro elements

public class PromptManager : MonoBehaviour
{
    //public Text promptText; // Change to public TextMeshProUGUI if using TextMeshPro
    [SerializeField] public TextMeshProUGUI promptText; // Change to public TextMeshProUGUI if using TextMeshPro
    [SerializeField] Canvas promptCanvas;

    public string[]forestprompts = new [] {
    "Welcome to the Forest Biome",
    "Kill enemies to survive",
    }; 

    public string[]mountainprompts = new [] {
    "Welcome to the mountain Biome",
    "Kill enemies to survive",
    }; 

    public string[]polarprompts = new [] {
    "Welcome to the polar Biome",
    "Kill enemies to survive",
    }; 

    public string[] prompts;
    public string[] status;
    private int currentPromptIndex = 0;
    private int currentStatusIndex = 0;

public enum PrompName {
    Forest,
    Mountain,
    Polar
} 

private PrompName biome;

public void SetPromptName (PrompName a){
    this.biome = a;
    switch(this.biome) {
        case PrompName.Forest: prompts = forestprompts;
        break;
        case PrompName.Mountain: prompts = mountainprompts;
        break;
        case PrompName.Polar: prompts = polarprompts;
        break;
    }
    promptCanvas.gameObject.SetActive(true);
}
    public void Start()
    {

        Debug.Log("PromptManager Start() called");
        if(prompts.Length > 0)
        {
            ShowPrompt(currentPromptIndex); // Show the first prompt
        }
    }

    private void ShowPrompt(int index)
    {
        Time.timeScale = 0;
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
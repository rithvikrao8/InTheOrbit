using UnityEngine;
using UnityEngine.UI; // Include if using UI Text or Buttons
using TMPro; // Uncomment if using TextMeshPro elements

public class StatusManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI livesText;
    [SerializeField] public TextMeshProUGUI killsText;
    [SerializeField] public TextMeshProUGUI damageText;
    [SerializeField] Canvas statusCanvas;

    private int kills;
    private int lives;
    private int damage;
    
    public void Start()
    {
        Reset(10,0,0);
        Debug.Log("StatusManager Start() called");
    }

    public void IncreaseKills()
    {
        kills++;
    }

    public void IncreaseDamage()
    {
        damage++;
    }

    public void DecreaseLives()
    {
        if (lives > 1)
        {
            lives--;
        }
    }

    private void Update()
    {
        killsText.text = kills.ToString();
        damageText.text = damage.ToString();
        if (lives > 0)
           livesText.text = lives.ToString();
        else
            livesText.text = " :(";
    }

    public void Reset(int l, int k, int d)
{
    kills = k;
        damage = d;
        lives = l;
        Update();
    }
}
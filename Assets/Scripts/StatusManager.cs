using UnityEngine;
using UnityEngine.UI; // Include if using UI Text or Buttons
using TMPro; // Uncomment if using TextMeshPro elements

public class StatusManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI killsText;
    [SerializeField] public TextMeshProUGUI damageText;
    [SerializeField] Canvas statusCanvas;

    private int kills;
    private int lives;
    private int damage;
    
    public void Start()
    {
        Reset(4,6);
        Debug.Log("StatusManager Start() called");
    }

    public void IncreaseKills()
    {
        kills++;
        Update();
    }

    public void IncreaseDamage()
    {
        damage++;
        Update();
    }

    private void Update()
    {
        killsText.text = kills.ToString();
        damageText.text = damage.ToString();
    }

    public void Reset(int k, int d)
{
    kills = k;
        damage = d;
        Update();
    }
}
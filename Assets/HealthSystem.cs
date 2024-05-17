using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Image healthbar;
    [SerializeField] private int maxHealth = 100;
    private float health;

    void Start()
    {
        health = maxHealth;
        healthbar.fillAmount = health / maxHealth;
    }

    public void DealDamage(int damage)
    {
        if (health == 0) { return; }
        StartCoroutine(TakeDamage(damage));
        //OnTakeDamage?.Invoke();
        //if (health == 0) 
        //{
            //OnDie?.Invoke();
        //}

Debug.Log(health);
    }

    public void Heal(int healing)
    {
        if (health == maxHealth) { return; }
        StartCoroutine(HealCoroutine(healing));
    }

    private IEnumerator TakeDamage(int damage)
    {
        int initialHealth = (int)health;
        for (int i = 0; i < damage * 10; i++)
        {
            health -= 0.1f;
            healthbar.fillAmount = health / maxHealth;
            yield return new WaitForSecondsRealtime(0.0001f);
        }
        health = Mathf.Max(initialHealth - damage, 0);
        healthbar.fillAmount = health / maxHealth;
    }

    private IEnumerator HealCoroutine(int healing)
    {
        int initialHealth = (int)health;
        for (int i = 0; i < healing * 10; i++)
        {
            health += 0.1f;
            health = Mathf.Clamp(health, 0, maxHealth);
            healthbar.fillAmount = health / maxHealth;
            yield return new WaitForSeconds(0.00001f);
        }
        health = Mathf.Min(initialHealth + healing, maxHealth);
        healthbar.fillAmount = health / maxHealth;
    }

    void Update()
    {
        Test();
    }

    private void Test()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DealDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(20);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int MaxHealth => maxHealth;

    private int currentHealth;
    public int CurrentHealth => currentHealth;

    public delegate void HealthChanged(int currentHealth);
    public event HealthChanged OnHealthChanged;

    private BarrierController barrierController;

    private void Start()
    {
        currentHealth = maxHealth;
        barrierController = FindObjectOfType<BarrierController>();

        if (barrierController == null)
        {
            Debug.LogError("BarrierController not found in the scene.");
        }
    }

    public void DealDamage(int damage)
    {
        if (currentHealth == 0) { return; }

        currentHealth = Mathf.Max(currentHealth - damage, 0);
        OnHealthChanged?.Invoke(currentHealth);

        Debug.Log($"Player current health: {currentHealth}");

        if (currentHealth == 0)
        {
            HandlePlayerDeath();
        }
    }

    private void HandlePlayerDeath()
    {
        if (barrierController != null)
        {
            barrierController.ResetBarriers();
        }
        Debug.Log("Player died. Barriers have been reset.");
    }
}

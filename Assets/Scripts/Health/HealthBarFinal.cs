using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFinal : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private HealthSystem playerHealth;

    private void Start()
    {
        if (playerHealth != null)
        {
            playerHealth.OnTakeDamage += UpdateHealthBar;
        }

        if (healthSlider != null && playerHealth != null)
        {
            healthSlider.maxValue = playerHealth.MaxHealth;
            healthSlider.value = playerHealth.CurrentHealth;
        }
    }

    private void UpdateHealthBar()
    {
        if (healthSlider != null && playerHealth != null)
        {
            healthSlider.value = playerHealth.CurrentHealth;
        }
    }
}

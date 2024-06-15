using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int MaxHealth => maxHealth;

    private int currentHealth;
    public int CurrentHealth => currentHealth;

    public event Action OnDie;
    public event Action OnTakeDamage;

    private Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component missing from this game object");
        }
    }

    public void DealDamage(int damage)
    {
        if (currentHealth == 0) { return; }

        currentHealth = Mathf.Max(currentHealth - damage, 0);
        OnTakeDamage?.Invoke();

        if (currentHealth == 0)
        {
            OnDie?.Invoke();
            PlayDeathAnimation();
        }

        Debug.Log($"Enemy current health: {currentHealth}");
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        if (animator != null)
        {
            animator.ResetTrigger("Death");
        }
    }

    private void PlayDeathAnimation()
    {
        if (animator != null)
        {
            Debug.Log("Playing Death Animation");
            animator.SetTrigger("Death");
        }
    }
}
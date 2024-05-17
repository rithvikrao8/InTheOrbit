using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private int PlayerFinalHealth;

    private void Start()
    {
        PlayerFinalHealth = maxHealth;
    }

    public void DealDamage(int damage)
    {
        if (PlayerFinalHealth == 0) { return; }

        PlayerFinalHealth = Mathf.Max(PlayerFinalHealth - damage, 0);

        Debug.Log(PlayerFinalHealth);
    }
}

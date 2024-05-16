using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    // Start is called before the first frame update
    private int health;
    void Start()
    {
       health = maxHealth;
    }

    public void DealDamage(int damage) 
    {
        if (health == 0) { return; }
        

        health = Mathf.Max(health - damage, 0);

        Debug.Log(health);
    }

    
}

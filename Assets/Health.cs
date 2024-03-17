using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthbar;
    public float healthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Test();


        
    }

    public void takeDamage(float damage)
    {
        healthAmount -= damage;
        healthbar.fillAmount = healthAmount / 100;
    }

    public void Heal(float healing)
    {
        healthAmount += healing;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthbar.fillAmount = healthAmount / 100;
    }

    public void Test()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            takeDamage(20);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Heal(20);
        }
    }

}

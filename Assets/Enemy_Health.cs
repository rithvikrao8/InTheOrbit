using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Image Enemy_Healthbar;
    public float healthAmount = 75f;
    private bool isPlayerAttacking = false;

    void Start()
    {
        
    }

    void Update()
    {
        Test();
    }

    public void PlayerAttack()
    {
        isPlayerAttacking = true;
    }

    public IEnumerator enemyTakeDamage(float damage)
    {
        if (!isPlayerAttacking)
            yield break;

        for (int i = 0; i < (damage * 10); i++)
        {
            healthAmount -= (float)0.1;
            Enemy_Healthbar.fillAmount = healthAmount / 75;
            yield return new WaitForSecondsRealtime((float)0.00001);
        }
        isPlayerAttacking = false;
    }

    public IEnumerator enemyHeal(float healing)
    {
        for (int i = 0; i < (healing * 10); i++)
        {
            healthAmount += (float)0.1;
            healthAmount = Mathf.Clamp(healthAmount, 0, 75);

            Enemy_Healthbar.fillAmount = healthAmount / 75;
            yield return new WaitForSeconds((float)0.00001);
        }
    }

    public IEnumerator Delay()
    {
        yield return null;
    }

    public void Test()
    {
        if (isPlayerAttacking)
        {
           StartCoroutine(enemyTakeDamage(20));
        }
        else
        {
            StartCoroutine(enemyHeal(10));
        }
    }
}

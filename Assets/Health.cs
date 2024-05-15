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

    public IEnumerator takeDamage(float damage)
    {

        for (int i = 0; i < (damage*10); i++)
        {

            healthAmount -= (float)0.1;
            healthbar.fillAmount = healthAmount / 100;
            yield return new WaitForSecondsRealtime((float)0.00001);

        }
    }

    public IEnumerator Heal(float healing)
    {

        for (int i = 0; i < (healing*10); i++)
        {
            healthAmount += (float)0.1;
            healthAmount = Mathf.Clamp(healthAmount, 0, 100);

            healthbar.fillAmount = healthAmount / 100;
            yield return new WaitForSeconds((float)0.00001);
        }
    }

    public IEnumerator Delay()
    {
        yield return null;
    }

    public void Test()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
           StartCoroutine(takeDamage(20));
            Debug.Log("balls");
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Heal(20));
        }
    }

}

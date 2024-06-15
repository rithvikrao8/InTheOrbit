using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    public EnemyHealth Boss1;
    public EnemyHealth Boss2;
    public EnemyHealth Boss3;

    private bool boss1Dead = false;
    private bool boss2Dead = false;
    private bool boss3Dead = false;

    private void Start()
    {
        if (Boss1 != null)
        {
            Boss1.OnDie += OnBoss1Die;
        }
        if (Boss2 != null)
        {
            Boss2.OnDie += OnBoss2Die;
        }
        if (Boss3 != null)
        {
            Boss3.OnDie += OnBoss3Die;
        }
    }

    private void OnBoss1Die()
    {
        boss1Dead = true;
        CheckAllBossesDead();
    }

    private void OnBoss2Die()
    {
        boss2Dead = true;
        CheckAllBossesDead();
    }

    private void OnBoss3Die()
    {
        boss3Dead = true;
        CheckAllBossesDead();
    }

    private void CheckAllBossesDead()
    {
        if (boss1Dead && boss2Dead && boss3Dead)
        {
            StartCoroutine(SwitchSceneAfterDelay(1f));
        }
    }

    private IEnumerator SwitchSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("WinningScene");
    }
}
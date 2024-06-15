using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCycleManager : MonoBehaviour
{
    public EnemyHealth Boss1;
    public EnemyHealth Boss2;
    public EnemyHealth Boss3;

    private int bossesDefeatedInRound = 0;
    private int currentCycle = 1;

    private void Start()
    {
        if (Boss1 != null) Boss1.OnDie += OnBossDie;
        if (Boss2 != null) Boss2.OnDie += OnBossDie;
        if (Boss3 != null) Boss3.OnDie += OnBossDie;
    }

    private void OnBossDie()
    {
        bossesDefeatedInRound++;

        if (currentCycle == 1 && bossesDefeatedInRound == 1)
        {
            StartCoroutine(ReturnToSpaceshipAndReset(1));
        }
        else if (currentCycle == 2 && bossesDefeatedInRound == 2)
        {
            StartCoroutine(ReturnToSpaceshipAndReset(2));
        }
        else if (currentCycle == 3 && bossesDefeatedInRound == 3)
        {
            StartCoroutine(WinGame());
        }
    }

    private IEnumerator ReturnToSpaceshipAndReset(int cycle)
    {
        // Return to spaceship scene
        SceneManager.LoadScene("SpaceshipScene");

        yield return new WaitForSeconds(1); // Adjust this if you want a different delay

        // Reset game state for the next round
        ResetBosses();
        bossesDefeatedInRound = 0;
        currentCycle = cycle + 1;

        // Return to game scene
        SceneManager.LoadScene("GameScene");
    }

    private void ResetBosses()
    {
        // Reset the health of all bosses and any other state
        Boss1.ResetHealth();
        Boss2.ResetHealth();
        Boss3.ResetHealth();
    }

    private IEnumerator WinGame()
    {
        yield return new WaitForSeconds(1); // Adjust this if you want a different delay

        // Load the winning scene
        SceneManager.LoadScene("WinningScene");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDeathHandler : MonoBehaviour
{
     public GameObject player; // This field is assigned via the Unity Editor
    public float delayBeforeSpaceship = 1.0f; // Duration to wait before sending the player to the spaceship
    public float delayBeforeReset = 5.0f; // Duration to wait before resetting the game scene

    private float deathTime = 0.0f;
    private bool deathSequenceStarted = false;

    void Start()
    {
        // Subscribe to the OnDie event
        player.GetComponent<HealthSystem>().OnDie += HandlePlayerDeath;
    }

    void HandlePlayerDeath()
    {
        if (!deathSequenceStarted)
        {
            deathSequenceStarted = true;
            deathTime = Time.time;
            StartCoroutine(DeathSequence());
        }
    }

    IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(delayBeforeSpaceship);
        SendPlayerToSpaceship();
        yield return new WaitForSeconds(delayBeforeReset);
        ResetGameScene();
    }

    void SendPlayerToSpaceship()
    {
        SceneManager.LoadScene("Spaceship");
    }

    void ResetGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}

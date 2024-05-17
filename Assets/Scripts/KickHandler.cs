using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickHandler : MonoBehaviour
{
    [SerializeField] private GameObject KickingAttack;
    public void EnableKickingAttack()
    {
        KickingAttack.SetActive(true);
    }
    public void DisableKickingAttack() 
    
    {
        KickingAttack.SetActive(false);
    }
}


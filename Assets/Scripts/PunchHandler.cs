using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchHandler : MonoBehaviour
{
    [SerializeField] private GameObject PunchingAttack;
    public void EnableWeapon()
    {
        PunchingAttack.SetActive(true);
    }
    public void DisableWeapon() 
    
    {
        PunchingAttack.SetActive(false);
    }
}

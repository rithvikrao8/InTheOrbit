using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReciever : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float floatingLevel = 2.5f;

    private float verticalVelocity;

    public Vector3 Movement => Vector3.up * verticalVelocity;

    private void Update()
    {
        // pass
    }
    
}

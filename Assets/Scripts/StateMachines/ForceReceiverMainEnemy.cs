using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReciever : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float floatingLevel = 0.0f;

    private float verticalVelocity;

    public Vector3 Movement => Vector3.up * verticalVelocity;

    private void Update()
    {
        if(controller.transform.position.y <= floatingLevel)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            verticalVelocity -= Physics.gravity.y * Time.deltaTime;
        }
    }
}

using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public GameObject[] barriers;

    // Function to activate the trigger on a specific barrier
    public void ActivateBarrierTrigger(int index)
    {
        if (index >= 0 && index < barriers.Length)
        {
            BoxCollider barrierCollider = barriers[index].GetComponent<BoxCollider>();
            if (barrierCollider != null)
            {
                barrierCollider.isTrigger = true;
            }
        }
    }

    // Function to reset all barriers' triggers
    public void ResetBarriers()
    {
        foreach (GameObject barrier in barriers)
        {
            BoxCollider barrierCollider = barrier.GetComponent<BoxCollider>();
            if (barrierCollider != null)
            {
                barrierCollider.isTrigger = false;
            }
        }
    }
}

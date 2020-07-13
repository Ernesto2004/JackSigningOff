using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverToggler : MonoBehaviour
{
    public Animator Lever_Animator;
    private string BoolName = "Activated";

    public void ActivateLever()
    {
        
        Lever_Animator.SetBool(BoolName, true);
        gameObject.tag = "InteractedWIth";
       
        gameObject.GetComponent<Interaction>().isInRange = false;
        
    }
}

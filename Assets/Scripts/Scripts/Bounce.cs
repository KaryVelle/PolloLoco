using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Bounce : TrampolineClass
{

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            charController = other.GetComponent<PlayerMovement>();
            charController.JumpHeight = 20f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            charController = other.GetComponent<PlayerMovement>();
            charController.JumpHeight = 1.2f;
        }
    }
    
}

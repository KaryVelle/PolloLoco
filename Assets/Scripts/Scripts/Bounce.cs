using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : TrampolineClass
{
    void Start()
    {
        colBounce.GetComponent<Collider>();
        player.GetComponent<CharacterController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            charController.JumpHeight = 20f;
        }
    }
    
}

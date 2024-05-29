using System.Collections;
using System.Collections.Generic;
using Mirror;
using StarterAssets;
using UnityEngine;

public class KillPollo : NetworkBehaviour
{
    private HandleDeath _handleDeath;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           _handleDeath = other.GetComponent<HandleDeath>();
           _handleDeath.Die();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class TrampolineClass : MonoBehaviour
{
    [SerializeField] public Collider colBounce;
    [SerializeField] public CharacterController player;
    [SerializeField] public PlayerMovement charController;

    public void Start()
    {
        charController = player.GetComponent<PlayerMovement>();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Mud : MonoBehaviour
{
    [SerializeField] public CharacterController player;
    [SerializeField] public PlayerMovement charController;
    void Start()
    {
        charController = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        charController.MoveSpeed = 0.5f;
        charController.SprintSpeed = 1.5f;
    }

    private void OnTriggerExit(Collider other)
    {
        charController.MoveSpeed = 2f;
        charController.SprintSpeed = 5.335f;
    }
}

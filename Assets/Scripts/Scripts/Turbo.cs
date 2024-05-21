using System;
using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.SyncDir;
using UnityEngine;
using StarterAssets;

public class Turbo : MonoBehaviour
{
    [SerializeField] public CharacterController player;
    [SerializeField] public PlayerMovement charController;
    [SerializeField] private Collider col;
    private Coroutine turbocor;
    void Start()
    {
        charController = player.GetComponent<PlayerMovement>();
        turbocor = null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (turbocor == null)
        {
            StartCoroutine(Tur());
        }
    }

    private IEnumerator Tur()
    {
        charController.SprintSpeed *= 2;
        charController.MoveSpeed *= 2;
        yield return new WaitForSeconds(1f);
        turbocor = null;
        charController.SprintSpeed /= 2;
        charController.MoveSpeed /= 2;
    }
}

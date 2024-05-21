using System;
using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.SyncDir;
using UnityEngine;
using StarterAssets;

public class Turbo : MonoBehaviour
{
    private PlayerMovement charController;
    private Coroutine turbocor;
    void Start()
    {
        turbocor = null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (turbocor == null)
        {
            charController = other.GetComponent<PlayerMovement>();
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

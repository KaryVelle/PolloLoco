using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnOffTimeline : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(TurnOff());
    }

    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(18);
        this.GameObject().SetActive(false);
    }
}

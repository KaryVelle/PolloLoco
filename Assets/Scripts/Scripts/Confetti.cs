using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confetti : MonoBehaviour
{
    [SerializeField] public ParticleSystem confetti;
    [SerializeField] public AudioSource phak;

    private void Start()
    {
        confetti = GetComponentInChildren<ParticleSystem>();
        phak = GameObject.FindGameObjectWithTag("pkah").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            confetti.Play();
            phak.Play();
        }
    }
}

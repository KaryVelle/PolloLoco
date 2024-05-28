using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Pendulo : MonoBehaviour
{
    public float move = 1.5f; 
    public float speed = 2.0f;
    public float direction = 1;
    private Quaternion startPos;
    public  Quaternion rot;
    
 
   private HandleDeath _handleDeath;
    
    void Start()
    {
        startPos = transform.rotation;
    }

    void Update()
    {
        rot = startPos;
        rot.x += direction * (move * Mathf.Sin(Time.time * speed));
        transform.rotation = rot;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          _handleDeath = other.GetComponent<HandleDeath>();
            Debug.Log("Player");
            _handleDeath.AddForce();
            
        }
    }
    
}


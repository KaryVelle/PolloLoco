using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Pendulo : NetworkBehaviour
{
    public float move = 1.5f; 
    public float speed = 2.0f;
    public float direction = 1;

    private Quaternion startPos;

    [SyncVar]
    private Quaternion syncRot;

    private HandleDeath _handleDeath;

    void Start()
    {
        startPos = transform.rotation;
    }

    void Update()
    {
        if (isServer)
        {
            // Solo el servidor actualiza la rotación
            syncRot = startPos;
            syncRot.x += direction * (move * Mathf.Sin(Time.time * speed));
            transform.rotation = syncRot;
        }
        else
        {
            // Los clientes interpolan hacia la rotación sincronizada
            transform.rotation = Quaternion.Lerp(transform.rotation, syncRot, Time.deltaTime * speed);
        }
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



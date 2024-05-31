using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ReadyCounter : NetworkBehaviour
{
    [SyncVar]
    public int ready = 0;

    // Esta función será llamada por el cliente para notificar al servidor
    [Command]
    public void CmdSetReady()
    {
        // Solo el servidor debería cambiar el valor de ready
        ready += 1;
    }
    
    // Esta función será llamada por el botón
    public void IsReady()
    {
        // Asegurarse de que este objeto está siendo controlado por el jugador local
        if (isLocalPlayer)
        {
            CmdSetReady();
            // Desactivar el botón solo en el cliente local
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("IsReady llamado desde un objeto que no es el jugador local.");
        }
    }
}
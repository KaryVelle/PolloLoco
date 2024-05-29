using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LobbyPOs : NetworkBehaviour
{
    public GameObject[] players;
    public Transform[] polloPosition;
    public NetworkManager nm;

    [SyncVar]
    public int polloOcup = 0;

    private void Start()
    {
        nm = FindObjectOfType<NetworkManager>();
    }
    private void Update()
    {
        polloOcup = nm.players;
    }

    public void MovePLayer(GameObject player)
    {
            player.transform.position = polloPosition[polloOcup].position;
    }

    [Server]
    public void AddPlayer(GameObject player)
    {
        // Añade el jugador al arreglo de jugadores y actualiza su posición
        players[polloOcup] = player;
        MovePLayer(player);
    }
}

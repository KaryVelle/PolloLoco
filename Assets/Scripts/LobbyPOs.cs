using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.UI;

public class LobbyPOs : NetworkBehaviour
{
    public GameObject[] players = new GameObject[3]; // Inicializa el array con tamaño 3
    public Transform[] polloPosition;
    public NetworkManager nm;
    [SyncVar]
    public int polloOcup = 0;

    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private GameObject canvasWood;

    [SerializeField] private GameObject fences;
    [SerializeField] private bool isready;
    [SerializeField] private AudioSource chickenGoSound;

    [SerializeField] private GameObject uiMusic;
    [SerializeField] private GameObject gameplayMusic;

    private void Start()
    {
        isready = true;
        nm = FindObjectOfType<NetworkManager>();
    }

    private void Update()
    {
        if (!isServer) return; // Solo el servidor debe ejecutar esta lógica

        polloOcup = nm.numPlayers; // Asegúrate de actualizar esto correctamente

        if (polloOcup >= 2 && isready)
        {
            isready = false;
            RpcActivateCanvasAndStartPollosRun();
        }
    }

    public void MovePLayer(GameObject player)
    {
        player.transform.position = polloPosition[polloOcup].position;
    }

    public void AddPlayer(GameObject player)
    {
        // Añade el jugador al arreglo de jugadores y actualiza su posición
        players[polloOcup] = player;
        MovePLayer(player);
    }

    [ClientRpc]
    void RpcDebugCountdown(string number)
    {
        tmp.text = number;
    }

    [ClientRpc]
    void RpcActivateCanvasAndStartPollosRun()
    {
        canvasWood.SetActive(true);
        StartCoroutine(StartPollosRun());
    }

    IEnumerator StartPollosRun()
    {
        RpcDebugCountdown("Ready?");
        uiMusic.SetActive(false);
        yield return new WaitForSeconds(3);
        canvasWood.SetActive(false);
        yield return new WaitForSeconds(2);
        yield return new WaitForSeconds(0.3f);
        fences.SetActive(false);
        gameplayMusic.SetActive(true);
    }
}
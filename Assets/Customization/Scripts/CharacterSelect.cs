using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;
using System.Collections;
using Cinemachine;
using Cinemachine;

namespace DapperDino.Mirror.Tutorials.CharacterSelection
{
    public class MyNetworkManager : NetworkManager
    {
        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            GameObject player = Instantiate(playerPrefab);
            NetworkServer.AddPlayerForConnection(conn, player);
        }
    }
    public class CharacterSelect : NetworkBehaviour
    {
        [SerializeField] private GameObject characterSelectDisplay = default;
        [SerializeField] private Transform characterPreviewParent = default;
        [SerializeField] private TMP_Text characterNameText = default;
        [SerializeField] private float turnSpeed = 90f;
        [SerializeField] private Character[] characters = default;
        [SerializeField] private GameObject destroy;
        [SerializeField] private GameObject destroy2;

        [SerializeField] private GameObject startCamGameObject;
        [SerializeField] private GameObject timeline;

        private int currentCharacterIndex = 0;
        private List<GameObject> characterInstances = new List<GameObject>();
        

        void Start()
        {
            startCamGameObject = GameObject.FindGameObjectWithTag("StartCam");
            
            Debug.Log("PlayerController Start: " + netId + " isLocalPlayer: " + isLocalPlayer);
            if (isLocalPlayer)
            {
                // Hacer visible la UI de selección de personaje solo para el jugador local
                characterSelectDisplay.SetActive(true);
            }
        }
        

        public override void OnStartClient()
        {
            startCamGameObject.SetActive(false);
            if (characterPreviewParent.childCount == 0)
            {
                foreach (var character in characters)
                {
                    GameObject characterInstance =
                        Instantiate(character.CharacterPreviewPrefab, characterPreviewParent);

                    characterInstance.SetActive(false);

                    characterInstances.Add(characterInstance);
                }
            }

            characterInstances[currentCharacterIndex].SetActive(true);
            characterNameText.text = characters[currentCharacterIndex].CharacterName;
           
            Destroy(destroy);
            characterSelectDisplay.SetActive(true);
        }

        private void Update()
        {
            destroy = GameObject.FindGameObjectWithTag("Destroy");
            destroy2 = GameObject.FindGameObjectWithTag("Destroy");
           Destroy(destroy2);
            Destroy(destroy);
            characterPreviewParent.RotateAround(
                characterPreviewParent.position,
                characterPreviewParent.up,
                turnSpeed * Time.deltaTime);
        }

        public void Select()
        {
            CmdCreateCharacter(currentCharacterIndex);
            characterSelectDisplay.SetActive(false);
        }

        [Command(requiresAuthority = false)]
        public void CmdCreateCharacter(int characterIndex, NetworkConnectionToClient sender = null)
        {
            GameObject characterInstance = Instantiate(characters[characterIndex].GameplayCharacterPrefab);
            NetworkServer.Spawn(characterInstance, sender);
            NetworkServer.AddPlayerForConnection(sender, characterInstance);
        }

        public void Right()
        {
            characterInstances[currentCharacterIndex].SetActive(false);

            currentCharacterIndex = (currentCharacterIndex + 1) % characterInstances.Count;

            characterInstances[currentCharacterIndex].SetActive(true);
            characterNameText.text = characters[currentCharacterIndex].CharacterName;
        }

        public void Left()
        {
            characterInstances[currentCharacterIndex].SetActive(false);

            currentCharacterIndex--;
            if (currentCharacterIndex < 0)
            {
                currentCharacterIndex += characterInstances.Count;
            }

            characterInstances[currentCharacterIndex].SetActive(true);
            characterNameText.text = characters[currentCharacterIndex].CharacterName;
        }
        
    }
}



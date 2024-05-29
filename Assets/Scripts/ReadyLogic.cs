using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyLogic : MonoBehaviour
{
    public HandleDeath[] isready;
    public Transform[] startpos;
    public bool canTake = true;
    public bool canMove = false;
    public LobbyPOs lp;

    private void Update()
    {
        if (lp.polloOcup == 2 && canTake)
        {
            isready = FindObjectsOfType<HandleDeath>();
            canTake = false;
            canMove = true;
        }
        if(canMove && isready[0].isready && isready[1].isready && isready[2].isready)
        {
            canMove = false;
            MoveToStartPos();
        }
    }

    public void MoveToStartPos()
    {
        foreach (HandleDeath han in isready)
        {
            CharacterController chara = han.gameObject.GetComponent<CharacterController>();
            chara.enabled = false;
            han.gameObject.transform.position = startpos[0].position;
        }
    }
}

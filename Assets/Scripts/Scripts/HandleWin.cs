using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleWin : MonoBehaviour
{

    [SerializeField] private List<GameObject> winners;
    [SerializeField] private Transform firstPlaceTransform;
    [SerializeField] private Transform secondPlaceTransform;
    [SerializeField] private Transform thirdPlaceTransform;
        
    public void GetWinners( GameObject winner)
    {
        winners.Add(winner);
        var characterController = winner.GetComponent<CharacterController>();
        characterController.enabled = false;

        var firstPlace = winners[winners.Count];
        var secondPlace = winners[winners.Count - 1];
        var thirdPlace = winners[winners.Count - 2];
    }
}

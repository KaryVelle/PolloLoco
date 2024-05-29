using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Mirror;
using Mirror.Examples.Benchmark;
using UnityEngine;

public class HandleWin : NetworkBehaviour
{
    [SerializeField] private List<GameObject> winners;
    [SerializeField] private Transform firstPlaceTransform;
    [SerializeField] private Transform secondPlaceTransform;
    [SerializeField] private Transform thirdPlaceTransform;
    

    [SerializeField] private GameObject vcPodium;
    [SerializeField] private GameObject _virtualCameraGameObject;
    [SerializeField] private CinemachineVirtualCamera vc;

    public override void OnStartAuthority()
    {
        vcPodium = GameObject.FindGameObjectWithTag("PodiumCam");
        _virtualCameraGameObject = GameObject.FindGameObjectWithTag("PlayerFollowCamera");
        vc = _virtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        firstPlaceTransform = GameObject.FindGameObjectWithTag("FirstPlace").transform;
        secondPlaceTransform = GameObject.FindGameObjectWithTag("SecondPlace").transform;
        thirdPlaceTransform = GameObject.FindGameObjectWithTag("ThirdPlace").transform;
    }

    public override void OnStartServer()
    {
        vcPodium.SetActive(false);
    }

    public void GetWinners(GameObject winner)
    {
        winners.Add(winner);
        Debug.Log(winners);

        if (winners.Count == 1)
        {
            var firstPlace = winners[0];
            var characterController1 = firstPlace.GetComponent<CharacterController>();
            characterController1.enabled = false;
            characterController1.gameObject.transform.position = firstPlaceTransform.position;
            characterController1.enabled = true;
            var randomPlayer = GameObject.FindGameObjectWithTag("Player");
            vc.Follow = randomPlayer.transform;
            vc.LookAt = randomPlayer.transform;


        }

        if (winners.Count == 2)
        {
            var secondPlace = winners[1];
            var characterController2 = secondPlace.GetComponent<CharacterController>();
            characterController2.enabled = false;
            characterController2.gameObject.transform.position = secondPlaceTransform.position;
            characterController2.enabled = true;
            vcPodium.SetActive(true);
           
           
        }

       // if (winners.Count == 3)
        //{
         //   var thirdPlace = winners[2];
         //   var characterController3 = thirdPlace.GetComponent<CharacterController>();
         //   characterController3.enabled = false;
        //    characterController3.gameObject.transform.position = thirdPlaceTransform.position;
        //   characterController3.enabled = true;
           
           
       // }

    }
}


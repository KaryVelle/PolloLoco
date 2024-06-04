using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalChecker : MonoBehaviour
{
    public ParticleSystem confetti;
    private CheckChecker _checker;
    [SerializeField] private Transform lastPointTransform;
    [SerializeField] private Transform currentTransform;
    
    [SerializeField] private int laps;
    
    [SerializeField] private HandleWin handleWin;

    private void Start()
    {
        confetti = GameObject.FindGameObjectWithTag("Confetti1").GetComponent<ParticleSystem>();
        lastPointTransform = GameObject.FindGameObjectWithTag("Checkpoint7").transform;
        currentTransform = GameObject.FindGameObjectWithTag("Goal").transform;
        _checker = GetComponent<CheckChecker>();
        handleWin = FindObjectOfType<HandleWin>();
    }

    public void Goal()
    {
        if ((_checker.lastPointLoad == lastPointTransform.transform) &&
            _checker.currentPointLoad == currentTransform)
        {
           CountLaps();
        }
    }

    private void CountLaps()
    {
        laps += 1;
        if (laps == 1)
        {
           handleWin.GetWinners(gameObject);
           confetti.Play();
        }
    }
    
}

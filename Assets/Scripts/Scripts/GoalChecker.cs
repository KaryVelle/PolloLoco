using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalChecker : MonoBehaviour
{
    private CheckChecker _checker;
    [SerializeField] private Transform lastPointTransform;
    [SerializeField] private Transform currentTransform;
    
    [SerializeField] private int laps;
    
    [SerializeField] private HandleWin handleWin;

    private void Start()
    {
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
           Debug.Log("Meta");
        }
    }

    private void CountLaps()
    {
        laps += 1;
        Debug.Log(laps);
        if (laps == 1)
        {
           handleWin.GetWinners(gameObject);
        }
    }
    
}

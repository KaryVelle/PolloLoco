using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChecker : CheckpointCheckerClass
{
    [SerializeField] private GoalChecker _goalChecker;
    
    private void Start()
    {
        _goalChecker = GetComponent<GoalChecker>();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Checkpoint") || other.CompareTag("Checkpoint7")|| (other.CompareTag("Goal")))
        {
            currentPointLoad = other.GetComponent<Transform>();
            checkpoints.Add(currentPointLoad);

            if (lastPointLoad == currentPointLoad)
            {
                checkpoints.Remove(currentPointLoad);
            }
            
            if (checkpoints.Count >= 2)
            {
                lastPointLoad = checkpoints[checkpoints.Count - 2];
                _goalChecker.Goal();
            }
            else
            {
                lastPointLoad = null; 
            }
        }
    }
    
}

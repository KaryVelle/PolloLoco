using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCheckerClass : MonoBehaviour
{
    [Header("Transform")] [SerializeField] public List<Transform> checkpoints;
    [SerializeField] public Transform currentPointLoad;

    public Transform AgregarCheckpoint(Transform currentpoint)
    {
        checkpoints.Add(currentpoint);
        int lastpoint = checkpoints.Count;
        currentPointLoad = checkpoints[lastpoint - 1];
        return currentPointLoad;
    }
}

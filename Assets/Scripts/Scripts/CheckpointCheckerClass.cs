using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCheckerClass : MonoBehaviour
{
    [Header("Transform")] [SerializeField] public List<Transform> checkpoints;
    [SerializeField] public Transform currentPointLoad;
    [SerializeField] public Transform lastPointLoad;
    
    
}
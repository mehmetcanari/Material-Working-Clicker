using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Dreamteck.Splines;
using Dreamteck.Editor;

public class RawProduce : MonoBehaviour
{
    public GameObject _rawMaterial;
    [HideInInspector] public UnityEvent TaskCalling;
    public SplineComputer _mineConveyorPath;

    private void Start()
    {
        SendActiveData(CurrentMine.Instance);
        
        TaskCalling.AddListener(ProduceStone);
    }

    private void SendActiveData(CurrentMine _adress)
    {
        _adress._activeMine = this.gameObject;
    }
    
    public Vector3 ConveyorStartPosition()
    {
        Vector3 startPosition = _mineConveyorPath.transform.TransformPoint(_mineConveyorPath.EvaluatePosition(0f));

        return startPosition;
    }
    
    public void ProduceStone()
    {
        var spawnedStone = Instantiate(_rawMaterial, ConveyorStartPosition(), Quaternion.identity);

        spawnedStone.GetComponent<SplineFollower>().spline = _mineConveyorPath;
    }
}

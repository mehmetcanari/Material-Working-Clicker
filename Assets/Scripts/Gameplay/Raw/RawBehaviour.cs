using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using Dreamteck.Splines;
using Dreamteck.Editor;

public class RawBehaviour : ProduceDataset
{
    public GameObject _rawMaterial;
    public SplineComputer _mineConveyorPath;

    private void Start()
    {
        SendActiveData(CurrentMine.Instance);
    }

    private void SendActiveData(CurrentMine _adress)
    {
        _adress._activeMine = this.gameObject;
    }
}

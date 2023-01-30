using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Dreamteck.Splines;
using Dreamteck.Splines.Editor;
using UnityEngine;

public class RawTask : MonoBehaviour
{
    private void OnEnable()
    {
        SetConveyorSpeed(3);
    }

    private void SetConveyorSpeed(int _targetSpeed)
    {
        SplineFollower _follower = gameObject.GetComponent<SplineFollower>();

        _follower.followSpeed = _targetSpeed;
    }
    
    private double CalculatedPosition()
    {
        SplineFollower _follower = gameObject.GetComponent<SplineFollower>();

        var _percent = _follower.GetPercent();

        return _percent;
    }

    //ReSharper disable Unity.PerformanceAnalysis
    private void EndTask()
    {
        if (CalculatedPosition() >= 1f)
        {
            //SEND PHASE 2 DATA
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        switch (StateManager.Instance._states)
        {
            case GameStates.Play:
                EndTask();
                break;
        }
    }
}

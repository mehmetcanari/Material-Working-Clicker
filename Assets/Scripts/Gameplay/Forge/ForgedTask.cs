using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.Serialization;

public class ForgedTask : MonoBehaviour
{
    public ForgedType _forgedType;
    
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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ProcessingBehaviour _processingBehaviour))
        {
            gameObject.GetComponent<Collider>().enabled = false;

            switch (_forgedType)
            {
                case ForgedType.V1:
                    _processingBehaviour.V1ProduceTask();
                    break;
                
                case ForgedType.V2:
                    _processingBehaviour.V2ProduceTask();
                    break;
                    
                case ForgedType.V3:
                    _processingBehaviour.V3ProduceTask();
                    break;
            }
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

public enum ForgedType
{
    V1,
    V2,
    V3
}

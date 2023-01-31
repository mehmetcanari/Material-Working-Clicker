using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class ItemTask : MonoBehaviour
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

public enum ItemType
{
    V1,
    V2,
    V3
}

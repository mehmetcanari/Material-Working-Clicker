using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Dreamteck.Splines;
using Dreamteck.Splines.Editor;
using UnityEngine;

public class RawTask : MonoBehaviour
{
    public MaterialType _Material;
    
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
        if (other.gameObject.CompareTag("Forge"))
        {
            gameObject.GetComponent<Collider>().enabled = false;

            switch (_Material)
            {
                case MaterialType.V1:
                    other.GetComponent<ITypeDefine>().ProduceV1Ingot();
                    break;
                
                case MaterialType.V2:
                    other.GetComponent<ITypeDefine>().ProduceV2Ingot();
                    break;
                
                case MaterialType.V3:
                    other.GetComponent<ITypeDefine>().ProduceV3Ingot();
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

public enum MaterialType
{
    V1,
    V2,
    V3
}

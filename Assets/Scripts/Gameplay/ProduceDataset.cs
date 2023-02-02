using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using DG.Tweening;

public abstract class ProduceDataset : MonoBehaviour
{
    protected Vector3 ConveyorStartPosition(SplineComputer _targetPath)
    {
        Vector3 startPosition = _targetPath.transform.TransformPoint(_targetPath.EvaluatePosition(0f));

        return startPosition;
    }
    
    protected void Tweening(Vector3 _tweenValue, Transform _targetObject)
    {
        Vector3 _defaultScale = _targetObject.transform.localScale;

        Vector3 _adjustedScale = _tweenValue;

        _targetObject.transform.DOScale(_adjustedScale, 0.1f).OnComplete(() =>
        {
            _targetObject.transform.DOScale(_defaultScale, 0.1f);
        });
    }
    
    protected void ProduceTargetItem(GameObject _definedItem , SplineComputer _targetComputer, Vector3 _tweenValue,Transform _targetTweenObject)
    {
        Tweening(_tweenValue, _targetTweenObject);
        
        var spawnedItem = Instantiate(_definedItem, ConveyorStartPosition(_targetComputer), Quaternion.identity);

        Vector3 defaultItemScale = spawnedItem.transform.localScale;
        
        spawnedItem.transform.localScale = Vector3.zero;

        spawnedItem.transform.DOScale(defaultItemScale, 0.5f);

        spawnedItem.GetComponent<SplineFollower>().spline = _targetComputer;

        spawnedItem.AddComponent<GlobalTask>();
    }
}

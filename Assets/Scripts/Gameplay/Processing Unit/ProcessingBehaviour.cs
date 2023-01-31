using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.Serialization;

public class ProcessingBehaviour : MonoBehaviour, ITypeDefine
{
    [FormerlySerializedAs("_processingUnityPath")] public SplineComputer _marketPath;
    public ProductData _itemStore;
    
    public Vector3 ConveyorStartPosition()
    {
        Vector3 startPosition = _marketPath.transform.TransformPoint(_marketPath.EvaluatePosition(0f));

        return startPosition;
    }
    
    protected void ProcessingUnitTweening()
    {
        Vector3 _defaultScale = gameObject.transform.localScale;

        Vector3 _adjustedScale = new Vector3(1.5f, 1.5f, 1.5f);

        gameObject.transform.DOScale(_adjustedScale, 0.1f).OnComplete(() =>
        {
            gameObject.transform.DOScale(_defaultScale, 0.1f);
        });
    }
    
    private void ProduceItem(GameObject _definedItem)
    {
        ProcessingUnitTweening();
        
        var spawnedItem = Instantiate(_definedItem, ConveyorStartPosition(), Quaternion.identity);

        Vector3 defaultItemScale = spawnedItem.transform.localScale;
        
        spawnedItem.transform.localScale = Vector3.zero;

        spawnedItem.transform.DOScale(defaultItemScale, 0.5f);

        spawnedItem.GetComponent<SplineFollower>().spline = _marketPath;
    }
    
    public void V1ProduceTask()
    {
        ProduceItem(_itemStore._producedItemV1);
    }

    public void V2ProduceTask()
    {
        ProduceItem(_itemStore._producedItemV2);
    }

    public void V3ProduceTask()
    {
        ProduceItem(_itemStore._producedItemV3);
    }
}

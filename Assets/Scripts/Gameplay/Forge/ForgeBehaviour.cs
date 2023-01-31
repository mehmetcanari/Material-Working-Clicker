using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class ForgeBehaviour : MonoBehaviour, ITypeDefine
{
    public SplineComputer _processingUnityPath;
    [FormerlySerializedAs("_productData")] public IngotData ingotData;

    public Vector3 ConveyorStartPosition()
    {
        Vector3 startPosition = _processingUnityPath.transform.TransformPoint(_processingUnityPath.EvaluatePosition(0f));

        return startPosition;
    }
    
    protected void ForgeTweening()
    {
        Vector3 _defaultScale = gameObject.transform.localScale;

        Vector3 _adjustedScale = new Vector3(2, 2, 2);

        gameObject.transform.DOScale(_adjustedScale, 0.1f).OnComplete(() =>
        {
            gameObject.transform.DOScale(_defaultScale, 0.1f);
        });
    }
    
    private void ProduceIngot(GameObject _definedMaterial)
    {
        ForgeTweening();
        
        var spawnedIngot = Instantiate(_definedMaterial, ConveyorStartPosition(), Quaternion.identity);

        Vector3 defaultIngotScale = spawnedIngot.transform.localScale;
        
        spawnedIngot.transform.localScale = Vector3.zero;

        spawnedIngot.transform.DOScale(defaultIngotScale, 0.5f);

        spawnedIngot.GetComponent<SplineFollower>().spline = _processingUnityPath;
    }
    
    public void V1ProduceTask()
    {
        ProduceIngot(ingotData._forgedProductV1);
    }

    public void V2ProduceTask()
    {
        ProduceIngot(ingotData._forgedProductV2);
    }

    public void V3ProduceTask()
    {
        ProduceIngot(ingotData._forgedProductV3);
    }
}

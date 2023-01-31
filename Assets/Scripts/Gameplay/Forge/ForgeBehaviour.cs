using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class ForgeBehaviour : ProduceDataset, ITypeDefine
{
    public SplineComputer _processingUnityPath;
    [FormerlySerializedAs("_productData")] public IngotData ingotData;
    
    public void V1ProduceTask()
    {
        ProduceTargetItem(ingotData._forgedProductV1, _processingUnityPath);
        Tweening(new Vector3(2,2,2), transform);
    }

    public void V2ProduceTask()
    {
        ProduceTargetItem(ingotData._forgedProductV2, _processingUnityPath);
        Tweening(new Vector3(2,2,2), transform);
    }

    public void V3ProduceTask()
    {
        ProduceTargetItem(ingotData._forgedProductV3, _processingUnityPath);
        Tweening(new Vector3(2,2,2), transform);
    }
}

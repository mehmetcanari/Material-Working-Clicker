using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.Serialization;

public class ProcessingBehaviour : ProduceDataset, ITypeDefine
{
    [FormerlySerializedAs("_processingUnityPath")] public SplineComputer _marketPath;
    public ProductData _itemStore;
    
    public void V1ProduceTask()
    {
        ProduceTargetItem(_itemStore._producedItemV1, _marketPath);
        Tweening(new Vector3(1.5f,1.5f,1.5f), transform);
    }

    public void V2ProduceTask()
    {
        ProduceTargetItem(_itemStore._producedItemV2, _marketPath);
        Tweening(new Vector3(1.5f,1.5f,1.5f), transform);
    }

    public void V3ProduceTask()
    {
        ProduceTargetItem(_itemStore._producedItemV3, _marketPath);
        Tweening(new Vector3(1.5f,1.5f,1.5f), transform);
    }
}

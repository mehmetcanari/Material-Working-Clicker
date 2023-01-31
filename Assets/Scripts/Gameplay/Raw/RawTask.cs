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
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ForgeBehaviour _forgeBehaviour))
        {
            gameObject.GetComponent<Collider>().enabled = false;

            switch (_Material)
            {
                case MaterialType.V1:
                    _forgeBehaviour.V1ProduceTask();
                    break;
                
                case MaterialType.V2:
                    _forgeBehaviour.V2ProduceTask();
                    break;
                
                case MaterialType.V3:
                    _forgeBehaviour.V3ProduceTask();
                    break;
            }
        }
    }
}

public enum MaterialType
{
    V1,
    V2,
    V3
}

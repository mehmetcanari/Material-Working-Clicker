using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.Serialization;

public class ForgedTask : MonoBehaviour
{
    public ForgedType _forgedType;
    
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
}

public enum ForgedType
{
    V1,
    V2,
    V3
}

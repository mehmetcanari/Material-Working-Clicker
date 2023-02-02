using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemTask : MonoBehaviour
{
    public ItemType _itemType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ISeller _seller))
        {
            gameObject.GetComponent<Collider>().enabled = false;

            switch (_itemType)
            {
                case ItemType.V1:
                    _seller.SellableV1();
                    break;
                
                case ItemType.V2:
                    _seller.SellableV2();
                    break;
                
                case ItemType.V3:
                    _seller.SellableV3();
                    break;
            }
        }
    }
}

public enum ItemType
{
    V1,
    V2,
    V3
}

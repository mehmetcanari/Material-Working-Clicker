using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class ItemTask : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MarketSelling _seller))
        {
            gameObject.GetComponent<Collider>().enabled = false;

            switch (_seller._marketLevel)
            {
                case MarketLevel.Level1:
                    _seller.SellableV1();
                    break;
                
                case MarketLevel.Level2:
                    _seller.SellableV2();
                    break;
                
                case MarketLevel.Level3:
                    _seller.SellableV3();
                    break;
            }
        }
    }
}


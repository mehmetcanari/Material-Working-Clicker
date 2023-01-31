using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Product Data", menuName = "Items", order = 1)]
public class ProductData : ScriptableObject
{
    public GameObject _producedItemV1;
    public GameObject _producedItemV2;
    public GameObject _producedItemV3;
}

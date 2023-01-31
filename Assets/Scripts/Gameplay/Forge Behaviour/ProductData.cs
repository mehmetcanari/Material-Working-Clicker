using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Data", menuName = "Product Store", order = 1)]
public class ProductData : ScriptableObject
{
    public GameObject _forgedProductV1;
    public GameObject _forgedProductV2;
    public GameObject _forgedProductV3;
}

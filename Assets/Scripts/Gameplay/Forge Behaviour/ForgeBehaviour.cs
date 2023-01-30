using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeBehaviour : MonoBehaviour, ITypeDefine
{
    public void ProduceV1Ingot()
    {
        Debug.Log("LEVEL 1 INGOT PRODUCED");
    }

    public void ProduceV2Ingot()
    {
        Debug.Log("LEVEL 2 INGOT PRODUCED");
    }

    public void ProduceV3Ingot()
    {
        Debug.Log("LEVEL 3 INGOT PRODUCED");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sell : MonoBehaviour
{
    protected abstract void SellProduct(int _amount, Currency _currency);

    protected abstract void TweenMarket(Vector3 _tweenValue, Transform _targetObject);
}

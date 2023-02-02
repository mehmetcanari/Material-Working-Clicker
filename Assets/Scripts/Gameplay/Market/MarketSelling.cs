using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MarketSelling : Sell, ISeller
{
    public Currency _currency;
    public MarketLevel _marketLevel;
    
    public void SellableV1()
    {
        if(_marketLevel == MarketLevel.Level1)
        SellProduct(25, _currency);
    }

    public void SellableV2()
    {
        if(_marketLevel == MarketLevel.Level2)
        SellProduct(50, _currency);
    }

    public void SellableV3()
    {
        if(_marketLevel == MarketLevel.Level3)
        SellProduct(100, _currency);
    }

    protected override void SellProduct(int _amount, Currency _currency)
    {
        _currency.AddCurrency(_amount);
        
        TweenMarket(Vector3.one * 1.25f, transform);
    }

    protected override void TweenMarket(Vector3 _tweenValue, Transform _targetObject)
    {
        Vector3 _defaultScale = _targetObject.transform.localScale;

        Vector3 _adjustedScale = _tweenValue;

        _targetObject.transform.DOScale(_adjustedScale, 0.1f).OnComplete(() =>
        {
            _targetObject.transform.DOScale(_defaultScale, 0.1f);
        });
    }
}

public enum MarketLevel
{
    Level1,
    Level2,
    Level3
}

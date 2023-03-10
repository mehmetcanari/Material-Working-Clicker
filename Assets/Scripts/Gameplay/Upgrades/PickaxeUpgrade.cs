using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Dreamteck;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class PickaxeUpgrade : Upgradables
{
    public Mining _mining;
    public Currency _currency;

    public TextMeshProUGUI _upgradeText;
    public Button _upgradeButton;
    private int _upgradeCount = 0;
    public int _upgradeCost;

    private void Start()
    {
        SetUpgradeValue(_upgradeText, _upgradeCost);
    }

    public override void Pickaxe() { Buy(_currency); }
    public override void Mine() { }
    public override void Market() { }
    
    private void UpgradePickaxe()
    {
        DOTween.Rewind("Mining");
        _mining.Second -= 0.25f;
        _mining.HitCalling?.Invoke();
        _mining._hitAllow = true;
        _upgradeCount++;
    }
    
    private void Buy(Currency currency)
    {
        if (_currency.GetCurrency() >= _upgradeCost)
        {
            CheckBuyCount(_upgradeCount, _upgradeButton, 3);
            UpgradePickaxe();
            currency.DecreaseCurrency(_upgradeCost);
            TweenUpgraded(new Vector3(4.5f, 4.5f, 4.5f), _mining._pickaxe.transform);
        }
    }
}


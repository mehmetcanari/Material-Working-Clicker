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
        SetUpgradeValue();
    }

    public override void Pickaxe() { Buy(_currency); }
    public override void Mine() { }
    public override void Market() { }

    private void SetUpgradeValue()
    {
        _upgradeText.SetText(_upgradeCost.ToString());
    }
    
    private void UpgradePickaxe()
    {
        _mining.Second -= 0.25f;
        DOTween.Rewind("Mining");
        _mining.HitCalling?.Invoke();
        _mining._hitAllow = true;
    }

    private void CheckBuyCount()
    {
        _upgradeCount++;
        if (_upgradeCount >= 3)
        {
            _upgradeButton.GetComponent<Button>().interactable = false;
        }
    }

    private void Buy(Currency currency)
    {
        if (_currency.GetCurrency() >= _upgradeCost)
        {
            CheckBuyCount();
            UpgradePickaxe();
            currency.DecreaseCurrency(_upgradeCost);
        }
    }
}


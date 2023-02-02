using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MineUpgrade : Upgradables
{
    public Currency _currency;

    public TextMeshProUGUI _upgradeText;
    public Button _upgradeButton;
    private int _upgradeCount = 0;
    public int _upgradeCost;
    public List<GameObject> _mines;

    private void Start()
    {
        SetUpgradeValue(_upgradeText, _upgradeCost);
    }


    public override void Pickaxe() { }

    public override void Mine() { Buy(_currency);}

    public override void Market() { }

    private void UpgradeMine()
    {
        _upgradeCount++;
        
        _mines[_upgradeCount - 1].gameObject.SetActive(false);
        _mines[_upgradeCount].gameObject.SetActive(true);
    }

    private void Buy(Currency currency)
    {
        if (_currency.GetCurrency() >= _upgradeCost)
        {
            CheckBuyCount(_upgradeCount, _upgradeButton, 2);
            UpgradeMine();
            currency.DecreaseCurrency(_upgradeCost);
            TweenUpgraded(new Vector3(2f, 2f, 2f), _mines[_upgradeCount].transform);
        }
    }
}

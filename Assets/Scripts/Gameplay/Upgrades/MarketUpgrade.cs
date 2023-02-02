using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketUpgrade : Upgradables
{
    public MarketSelling _marketSelling;
    public Currency _currency;

    public TextMeshProUGUI _upgradeText;
    public Button _upgradeButton;
    private int _upgradeCount = 0;
    public int _upgradeCost;
    public List<Canvas> _levelLabels;

    private void Start()
    {
        SetUpgradeValue(_upgradeText, _upgradeCost);
    }
    
    public override void Pickaxe() { }

    public override void Mine() { }

    public override void Market() { Buy(_currency); }

    private void Buy(Currency currency)
    {
        if (_currency.GetCurrency() >= _upgradeCost)
        {
            CheckBuyCount(_upgradeCount, _upgradeButton, 2);
            UpgradeMine();
            currency.DecreaseCurrency(_upgradeCost);
            TweenUpgraded(Vector3.one * 1.1f,_marketSelling._market.transform);
        }
    }
    
    private void UpgradeMine()
    {
        _upgradeCount++;
        ShowLevelLabel(_levelLabels);

        switch (_upgradeCount)
        {
            case 1:
                SwitchEnum(MarketLevel.Level2);
                break;
            
            case 2:
                SwitchEnum(MarketLevel.Level3);
                break;
            
        }
    }

    private void SwitchEnum(MarketLevel _desiredLevel)
    {
        _marketSelling._marketLevel = _desiredLevel;
    }

    private void ShowLevelLabel(List<Canvas> _labels)
    {
        _labels[_upgradeCount - 1].gameObject.SetActive(false);
        _labels[_upgradeCount].gameObject.SetActive(true);
    }
}

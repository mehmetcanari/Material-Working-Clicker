using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public abstract class Upgradables : MonoBehaviour
{
    public abstract void Pickaxe();

    public abstract void Mine();

    public abstract void Market();

    public void TweenUpgraded(Vector3 _tweenValue, Transform _targetObject)
    {
        DOTween.Kill("Complete");
        Vector3 _defaultScale = _targetObject.transform.localScale;

        Vector3 _adjustedScale = _tweenValue;

        _targetObject.transform.DOScale(_adjustedScale, 0.2f).SetId("Complete").OnComplete(() =>
        {
            _targetObject.transform.DOScale(_defaultScale, 0.2f).SetId("Complete");
        });
    }
    
    protected void SetUpgradeValue(TextMeshProUGUI _upgradeText, int _upgradeCost)
    {
        _upgradeText.SetText(_upgradeCost.ToString());
    }

    protected void CheckBuyCount(int _upgradeCount, Button _upgradeButton, int _maxUpgradeValue)
    {
        _upgradeCount++;
        if (_upgradeCount >= _maxUpgradeValue)
        {
            _upgradeButton.GetComponent<Button>().interactable = false;
        }
    }
}

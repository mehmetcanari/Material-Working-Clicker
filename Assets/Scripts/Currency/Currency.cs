using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Currency : MonoBehaviour
{
    private int currency;
    public TextMeshProUGUI currencyText;
    public Transform _currencyObject;

    private void Start()
    {
        currency = PlayerPrefs.GetInt("Currency", 0);

        UpdateCurrencyDisplay();
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
        PlayerPrefs.SetInt("Currency", currency);
        UpdateCurrencyDisplay();
        TweenCurrencyObject();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddCurrency(20);
        }
    }

    public int GetCurrency()
    {
        return currency;
    }

    private void UpdateCurrencyDisplay()
    {
        currencyText.text = currency.ToString();
    }

    private void TweenCurrencyObject()
    {
        var _defaultScale = _currencyObject.transform.localScale;

        DOTween.Kill("Tween");
        _currencyObject.transform.DOScale(Vector3.one * 1.2f, 0.1f).SetEase(Ease.Linear).SetId("Tween").OnComplete(() =>
        {
            _currencyObject.transform.DOScale(_defaultScale, 0.1f).SetEase(Ease.Linear);
        });
    }
}






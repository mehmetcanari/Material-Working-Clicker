using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    public TextMeshProUGUI _coinText;
    private int _coinValue;

    public void SetMoney(int _amount)
    {
        _coinValue += _amount;
        
        _coinText.SetText(_coinValue.ToString());
    }
}

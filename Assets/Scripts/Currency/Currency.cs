using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Currency : MonoBehaviour
{
    private int currency;
    public TextMeshProUGUI currencyText;

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
    }

    public int GetCurrency()
    {
        return currency;
    }

    private void UpdateCurrencyDisplay()
    {
        currencyText.text = currency.ToString();
    }
}






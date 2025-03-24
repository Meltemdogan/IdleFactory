using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    public float currentMoney = 5000f;
    public TMP_Text moneyText;
    public UnityAction<float> OnMoneyChanged;
    
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void AddMoney(float amount)
    {
        currentMoney += amount;
        OnMoneyChanged?.Invoke(currentMoney);
    }
    public void SpendMoney(float amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
        }
        OnMoneyChanged?.Invoke(currentMoney);
    }
    
    public float GetCurrentMoney()
    {
        return currentMoney;
    }
}
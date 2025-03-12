using System;
using TMPro;
using UnityEngine;

public class PlayerEconomy : MonoBehaviour
{
    public static PlayerEconomy Instance;
    public float currentMoney = 500f;
    public TMP_Text moneyText;
    
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void AddMoney(float amount)
    {
        currentMoney += amount;
        UpdateUI();
    }
    public void SpendMoney(float amount)
    {
        currentMoney -= amount;
        UpdateUI();
    }
    
    public void UpdateUI()
    {
        moneyText.text = "Money: " + currentMoney;
    }
}

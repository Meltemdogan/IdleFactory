using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Machine> activeMachines = new List<Machine>();
    public TMP_Text goldPerSecondText;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    
    private void Update()
    {
        //UpdateGoldPerSecondUI();
    }
    
    public float GetTotalGoldPerSecond()
    {
        float totalGold = 0;
        foreach (var machine in activeMachines)
        {
            //totalGold += machine.machineData.goldPerSecond;
        }
        
        return totalGold;
    }
    private void UpdateGoldPerSecondUI()
    {
        goldPerSecondText.text = "Gold Per Second: " + GetTotalGoldPerSecond();
    }
    public void RegisterMachine(Machine newMachine)
    {
        activeMachines.Add(newMachine);
    }
}
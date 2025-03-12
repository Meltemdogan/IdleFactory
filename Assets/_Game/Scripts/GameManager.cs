using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Machine> activeMachines = new List<Machine>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    
    public void RegisterMachine(Machine machine)
    {
        activeMachines.Add(machine);
        if (machine.machineData.productData != null)
        {
            ProductPool.Instance.RegisterProductToPool(machine.machineData.productData);
        }
    }
}
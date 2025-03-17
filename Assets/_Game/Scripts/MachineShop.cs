using System;
using Unity.VisualScripting;
using UnityEngine;

public class MachineShop : MonoBehaviour
{
    public static MachineShop Instance;
    public Transform[] spawnPoints;
    [SerializeField] private Transform mainConveyorEndPoint;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void BuyMachine(MachineData machineData, int machineIndex)
    {
        if(PlayerEconomy.Instance.currentMoney >= machineData.price)
        {
            PlayerEconomy.Instance.SpendMoney(machineData.price);
            
            Transform spawnPoint = spawnPoints[machineIndex];
            
            GameObject machineObj = Instantiate(machineData.machinePrefab, spawnPoint.position, Quaternion.identity);
            Machine newMachine = machineObj.GetComponent<Machine>();
            newMachine.Initialize(mainConveyorEndPoint);
            
            GameManager.Instance.RegisterMachine(newMachine);
        }
        else
        {
            Debug.Log("Not enough money to buy this machine");
        }
    }
}

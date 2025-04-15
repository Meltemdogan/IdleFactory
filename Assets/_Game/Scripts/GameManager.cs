using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Machine> activeMachines = new List<Machine>();
    public List<Machine> machineDatas;
    public Transform firstSlotPoint;
    public GameObject machineSlotPrefab;
    public Transform machineSlotParent;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        InstantiateSlot();
    }

    public void RegisterMachine(Machine machine)
    {
        activeMachines.Add(machine);
        OrderManager.Instance.activeProducts.Add(machine.machineData.productData); 
        ProductPool.Instance.RegisterProductToPool(machine.machineData.productData);
    }
    [SerializeField] private int slotDistance = 8;
    public void InstantiateSlot()
    {
        for (int i = 0; i <machineDatas.Count ; i++)
        {
            Vector3 slotPosition = firstSlotPoint.position + new Vector3(i * slotDistance, 0, 0); // Adjust the position based on the index
            GameObject newMachineSlot = Instantiate(machineSlotPrefab, slotPosition, Quaternion.identity, machineSlotParent);
        }
    }
}
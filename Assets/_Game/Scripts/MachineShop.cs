using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class MachineShop : MonoBehaviour
{
    public static MachineShop Instance;
    
    public List<MachineData> machineDatas;
    public GameObject machineUIPrefab;
    public Transform machineUIParent;
    public Transform[] spawnPoints;
    public Transform firstMachinePoint;
    [SerializeField] private Transform mainConveyorEndPoint;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    
    private void Start()
    {
        uiInitialize();
    }
    
    public void uiInitialize()
    {
        for (int i = 0; i < machineDatas.Count; i++)
        {
            MachineData machineData = machineDatas[i];
            
            GameObject newMachineUI = Instantiate(machineUIPrefab, machineUIParent);
            
            TMP_Text nameText = newMachineUI.transform.Find("MachineNameText").GetComponent<TMP_Text>();
            Image iconImage = newMachineUI.transform.Find("MachineSprite").GetComponent<Image>();
            Button buyButton = newMachineUI.GetComponentInChildren<Button>();
            
            nameText.text = machineData.machineName;
            iconImage.sprite = machineData.machineSprite;
            
            int machineIndex = i;
            buyButton.onClick.AddListener(() => BuyMachine(machineData, machineIndex));
        }
    }
    
    public void BuyMachine(MachineData machineData, int machineIndex)
    {
        if (CurrencyManager.Instance.currentMoney >= machineData.price)
        {
            CurrencyManager.Instance.SpendMoney(machineData.price);
            
            if (machineIndex >= 0 && machineIndex < machineDatas.Count)
            {
                Vector3 spawnPoint = firstMachinePoint.position + new Vector3(machineIndex * 6, 0, 0);
                GameObject machineObj = Instantiate(machineData.machinePrefab, spawnPoint, Quaternion.identity);
                Machine newMachine = machineObj.GetComponent<Machine>();
                newMachine.Initialize(mainConveyorEndPoint);
                
                GameManager.Instance.RegisterMachine(newMachine);
            }
            else
            {
                Debug.LogError("Invalid machine index (machineDatas dışında): " + machineIndex);
            }
        }
        else
        {
            Debug.Log("Not enough money to buy this machine");
        }
    }
}
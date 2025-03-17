using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    public Button StoreButton;
    public Button CloseStoreButton;
    public GameObject StorePanel;
    public TMP_Text storageText;
    
    public Button BuyMachine1Button;
    public Button BuyMachine2Button;
    public Button BuyMachine3Button;
    public Button BuyMachine4Button;
    
    public MachineData machine1;
    public MachineData machine2;
    public MachineData machine3;
    public MachineData machine4;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        //MoneyText.text = "Money: " + PlayerEconomy.Instance.currentMoney;
        
        StoreButton.onClick.AddListener(OpenStore);
        CloseStoreButton.onClick.AddListener(CloseStore);
        
        BuyMachine1Button.onClick.AddListener(() => MachineShop.Instance.BuyMachine(machine1, 0));
        BuyMachine2Button.onClick.AddListener(() => MachineShop.Instance.BuyMachine(machine2, 1));
        BuyMachine3Button.onClick.AddListener(() => MachineShop.Instance.BuyMachine(machine3, 2));
        BuyMachine4Button.onClick.AddListener(() => MachineShop.Instance.BuyMachine(machine4, 3));
    }

    private void CloseStore()
    {
        StorePanel.SetActive(false);
    }
        

    private void OpenStore()
    {
        StorePanel.SetActive(true);
    }
    public void UpdateStorageText()
    {
        storageText.text = "Storage:";
        
        foreach (var product in FactoryStorage.Instance.storage)
        {
            storageText.text += product.Key.productName + ": " + product.Value + "\n";
        }
    }
}

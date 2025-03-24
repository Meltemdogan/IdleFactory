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
    
    public Button OrderButton;
    public Button CloseOrderButton;
    public GameObject OrderPanel;
    
    public TMP_Text storageText;
    public TMP_Text moneyText;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        StoreButton.onClick.AddListener(() => OpenPanel(StorePanel));
        CloseStoreButton.onClick.AddListener(() => ClosePanel(StorePanel));
        
        OrderButton.onClick.AddListener(() => OpenPanel(OrderPanel));
        CloseOrderButton.onClick.AddListener(() => ClosePanel(OrderPanel));
    }
    
    private void Update()
    {
        UpdateMoneyUI(CurrencyManager.Instance.GetCurrentMoney());
    }
    
    private void ClosePanel(GameObject Panel)
    {
        Panel.SetActive(false);
    }
    
    private void OpenPanel(GameObject Panel)
    {
        Panel.SetActive(true);
    }
    public void UpdateMoneyUI(float money)
    {
        moneyText.text = "Money: " + money;
    }
}

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
    public TMP_Text MoneyText;
    

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        StoreButton.onClick.AddListener(OpenStore);
        CloseStoreButton.onClick.AddListener(CloseStore);
    }

    private void CloseStore()
    {
        StorePanel.SetActive(false);
    }
        

    private void OpenStore()
    {
        StorePanel.SetActive(true);
    }
}

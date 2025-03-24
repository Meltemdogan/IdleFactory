using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;
    
    public GameObject orderUIPrefab;
    public Transform orderUIParent;
    public List<OrderData> activeOrders = new List<OrderData>();
    public List<OrderData> activeOrderData = new List<OrderData>();
    public List<ProductData> activeProducts = new List<ProductData>();
    public FactoryStorage factoryStorage;
    //public TMP_Text ordersUI;
    
    public float orderSpawnInterval = 10f;
    public int maxOrders = 3;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(GenerateOrders());
    }
    
    private void OnEnable()
    {
        FactoryStorage.OnProductAdded += StorageControl;
    }
    
    private void OnDisable()
    {
        FactoryStorage.OnProductAdded -= StorageControl;
    }
    
    private IEnumerator GenerateOrders()
    {
        while (true)
        {
            yield return new WaitForSeconds(orderSpawnInterval);

            if (activeOrders.Count < maxOrders)
            {
                OrderData newOrder = CreateRandomOrder();
                if (newOrder != null)
                {
                    activeOrders.Add(newOrder);
                    
                    GameObject orderUI = Instantiate(orderUIPrefab,orderUIParent);
                    newOrder.orderUI = orderUI;
                    
                    TMP_Text OrderText = orderUI.transform.Find("OrderText").GetComponent<TMP_Text>();
                    OrderText.text = newOrder.product + "\n" + newOrder.quantity + "x\n" + newOrder.reward + "₺";
                    
                    TMP_Text StorageControlText = orderUI.transform.Find("StorageControlText").GetComponent<TMP_Text>();
                    if (FactoryStorage.Instance.storage.ContainsKey(newOrder.product))
                    {
                        StorageControlText.text = FactoryStorage.Instance.storage[newOrder.product].productCount + " / " + newOrder.quantity;
                    }
                    else
                    {
                        StorageControlText.text = "0 / " + newOrder.quantity;
                    }
                    
                    
                    Button completeButton = orderUI.transform.Find("DeliveryButton").GetComponent<Button>();
                    completeButton.onClick.AddListener(() => CompleteOrder(newOrder));
                    
                }
            }
        }
    }
    
    
    public void StorageControl()
    {
        foreach (OrderData order in activeOrders)
        {
            TMP_Text storageText = order.orderUI.transform.Find("StorageControlText").GetComponent<TMP_Text>();
            if (FactoryStorage.Instance.storage.ContainsKey(order.product))
            {
                storageText.text = FactoryStorage.Instance.storage[order.product].productCount + " / " + order.quantity;  
            }
            else
            {
                storageText.text = "0 / " + order.quantity;
            }
        }
    }
    private OrderData CreateRandomOrder()
    {
        if (activeProducts.Count == 0)
        {
            Debug.LogWarning("Henüz üretimde olan bir ürün yok!");
            return null;
        }
        
        ProductData randomProduct = activeProducts[Random.Range(0, activeProducts.Count)];
        int randomQuantity = Random.Range(5, 20);
        int reward = randomQuantity * Random.Range(1, 5);
        
        return new OrderData() 
        {
            product = randomProduct,
            quantity = randomQuantity,
            reward = reward
        };
    }
    
    public void CompleteOrder(OrderData order)
    {
        if (factoryStorage.HasEnoughProducts(order.product, order.quantity))
        {
            factoryStorage.RemoveProducts(order.product, order.quantity);
            Destroy(order.orderUI);
            activeOrders.Remove(order);
            CurrencyManager.Instance.AddMoney(order.reward);
        }
    }
    
    public void TryCompleteOrder(int index)
    {
        if (index >= 0 && index < activeOrders.Count)
        {
            CompleteOrder(activeOrders[index]);
        }
    }
    [System.Serializable]
    public class OrderData 
    {
        public ProductData product;
        public int quantity;
        public int reward;
        public GameObject orderUI;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;
    
    public List<OrderData> possibleOrders;
    public List<OrderData> activeOrders = new List<OrderData>();
    public List<ProductData> activeProducts = new List<ProductData>();
    public FactoryStorage factoryStorage;
    public TMP_Text ordersUI;
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
                    //UpdateUI();
                    Debug.Log("Yeni sipariş oluşturuldu: " + newOrder.product + " " + newOrder.quantity + "x " + newOrder.reward + "₺");
                }
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

        OrderData generatedOrder = ScriptableObject.CreateInstance<OrderData>();
        generatedOrder.product = randomProduct;
        generatedOrder.quantity = randomQuantity;
        generatedOrder.reward = reward;
        
        return generatedOrder;
    }
    
    public void CompleteOrder(OrderData order)
    {
        if (factoryStorage.HasEnoughProducts(order.product, order.quantity))
        {
            factoryStorage.RemoveProducts(order.product, order.quantity);
            activeOrders.Remove(order);
            PlayerEconomy.Instance.AddMoney(order.reward);
            
            //UpdateUI();
        }
    }
    
    public void UpdateUI()
    {
        string orderText = "";
        foreach (OrderData order in activeOrders)
        {
            orderText += order.product + "\n" + order.quantity + "x\n" + order.reward + "₺\n\n";
        }
        
        ordersUI.text = orderText;
    }
    
    public void TryCompleteOrder(int index)
    {
        if (index >= 0 && index < activeOrders.Count)
        {
            CompleteOrder(activeOrders[index]);
        }
    }
}
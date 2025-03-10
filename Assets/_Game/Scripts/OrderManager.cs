using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class OrderManager : MonoBehaviour
{
    public List<OrderData> possibleOrders;
    public List<OrderData> activeOrders = new List<OrderData>();
    public FactoryStorage factoryStorage;
    public TMP_Text ordersUI;
    public float orderSpawnInterval = 10f;
    public int maxOrders = 3;
    
    private void Start()
    {
        StartCoroutine(GenerateOrders());
    }
    
    IEnumerator GenerateOrders()
    {
        yield return new WaitForSeconds(orderSpawnInterval);
        
        while (true)
        {
            if (activeOrders.Count < maxOrders)
            {
                OrderData newOrder = possibleOrders[UnityEngine.Random.Range(0, possibleOrders.Count)];
                activeOrders.Add(newOrder);
                UpdateUI();
            }
        }
    }
    
    public void CompleteOrder(OrderData order)
    {
        if (factoryStorage.HasEnoughProducts(order.requestedProduct, order.quantity))
        {
            factoryStorage.RemoveProducts(order.requestedProduct, order.quantity);
            activeOrders.Remove(order);
            PlayerEconomy.Instance.AddMoney(order.reward);
            UpdateUI();
        }
    }
    
    public void UpdateUI()
    {
        string orderText = "";
        foreach (OrderData order in activeOrders)
        {
            orderText += order.orderName + "\n";
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
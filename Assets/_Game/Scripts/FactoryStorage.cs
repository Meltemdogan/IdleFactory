using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FactoryStorage : MonoBehaviour
{
    public static FactoryStorage Instance;
    public Dictionary<ProductData, ProductStorageData> storage = new();
    public TMP_Text storageText;
    
    public GameObject productUIPrefab;
    public Transform productUIParent;
    
    public static UnityAction OnProductAdded;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddProduct(ProductData product) 
    {
        if (storage.ContainsKey(product))
        {
            storage[product].productCount++;
            OnProductAdded?.Invoke();
        }
        else
        {
            ProductStorageData productStorageData = new ProductStorageData();
            productStorageData.productCount = 1;
            storage.Add(product, productStorageData);
        }
        
        if (storage[product].productUI == null)
        {
            GameObject productObj = Instantiate(productUIPrefab, productUIParent);
            productObj.GetComponentInChildren<TMP_Text>().text = product.productName + " x" + storage[product].productCount;
            productObj.GetComponentInChildren<Image>().sprite = product.productSprite;
            storage[product].productUI = productObj;
        }
        else
        {
            GameObject productObj = storage[product].productUI;
            productObj.GetComponentInChildren<TMP_Text>().text = product.productName + " x" + storage[product].productCount;
            productObj.GetComponentInChildren<Image>().sprite = product.productSprite;
        }
    }
    
    public bool HasEnoughProducts(ProductData product, int quantity)
    {
        return storage.ContainsKey(product) && storage[product].productCount >= quantity;
    }
    
    public void RemoveProducts(ProductData product, int quantity)
    {
        if (HasEnoughProducts(product, quantity))
        {
            storage[product].productCount -= quantity;
            if (storage[product].productCount <= 0)
            {
                storage[product].productCount = 0;
            }
        }
    }
    public class ProductStorageData
    {
        public int productCount;
        public GameObject productUI;
    }
}

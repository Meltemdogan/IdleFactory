using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FactoryStorage : MonoBehaviour
{
    public static FactoryStorage Instance;
    public Dictionary<ProductData, int> storage = new Dictionary<ProductData, int>();
    public TMP_Text storageText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddProduct(ProductData product)
    {
        if (storage.ContainsKey(product))
        {
            storage[product]++;
        }
        else
        {
            storage.Add(product, 1);
        }
        //UIManager.Instance.UpdateStorageText();
        Debug.Log("Ürün eklendi: " + product.productName  + " Toplam: " + storage[product]);
    }
    
    public bool HasEnoughProducts(ProductData product, int quantity)
    {
        return storage.ContainsKey(product) && storage[product] >= quantity;
    }
    
    public void RemoveProducts(ProductData product, int quantity)
    {
        if (HasEnoughProducts(product, quantity))
        {
            storage[product] -= quantity;
            if (storage[product] <= 0)
            {
                storage.Remove(product);
            }
        }
    }
}

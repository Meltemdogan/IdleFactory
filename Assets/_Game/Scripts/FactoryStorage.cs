using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FactoryStorage : MonoBehaviour
{
    public Dictionary<ProductData, int> storage = new Dictionary<ProductData, int>();
    public TMP_Text storageText;
    
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
        
        UpdateStorageText();
    }
    
    private void UpdateStorageText()
    {
        storageText.text = "Storage:";
        
        foreach (var product in storage)
        {
            storageText.text += product.Key.productName + ": " + product.Value + "\n";
        }
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
        
        UpdateStorageText();
    }
}

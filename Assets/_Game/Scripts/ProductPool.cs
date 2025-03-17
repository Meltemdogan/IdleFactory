using System;
using System.Collections.Generic;
using UnityEngine;

public class ProductPool : MonoBehaviour
{
    public static ProductPool Instance;
   // public GameObject productPrefab;
    public int poolSize = 10;
    private Dictionary<ProductData, Queue<GameObject>> poolDictionary = new Dictionary<ProductData, Queue<GameObject>>();
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void RegisterProductToPool(ProductData productData)
    {
        if (!poolDictionary.ContainsKey(productData))
        {
            poolDictionary[productData] = new Queue<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(productData.productPrefab, transform);
                obj.SetActive(false);
                poolDictionary[productData].Enqueue(obj);
            }
        }
    }
    public GameObject GetProduct(ProductData productData, Vector3 position)
    {
        if (poolDictionary.ContainsKey(productData) && poolDictionary[productData].Count > 0)
        {
           GameObject obj = poolDictionary[productData].Dequeue();
           obj.transform.position = position;
           obj.SetActive(true);
           return obj;
        }
        else if (poolDictionary.ContainsKey(productData))
        {
            GameObject obj = Instantiate(productData.productPrefab, position, Quaternion.identity, transform);
            return obj;
        }

        return null;
    }
    
    public void ReturnProduct(ProductData productData, GameObject obj)
    {
        obj.SetActive(false);
        if (!poolDictionary.ContainsKey(productData))
        {
            poolDictionary[productData] = new Queue<GameObject>();
        }
        poolDictionary[productData].Enqueue(obj);
    }
}

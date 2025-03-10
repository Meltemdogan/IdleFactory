using System;
using System.Collections.Generic;
using UnityEngine;

public class ProductPool : MonoBehaviour
{
    public static ProductPool Instance;
    public GameObject productPrefab;
    public int poolSize = 10;
    private Queue<GameObject> productPool = new Queue<GameObject>();
    private Dictionary<string, Queue<GameObject>> productPools = new Dictionary<string, Queue<GameObject>>();
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    
    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newProduct = Instantiate(productPrefab, transform);
            newProduct.SetActive(false);
            productPool.Enqueue(newProduct);
        }
    }
    public GameObject GetProduct(Vector3 position)
    {
        if (productPool.Count > 0)
        {
           GameObject obj = productPool.Dequeue();
           obj.transform.position = position;
           obj.SetActive(true);
           return obj;
        }
        else
        {
            GameObject obj = Instantiate(productPrefab, position, Quaternion.identity, transform);
            return obj;
        }
    }
    public void ReturnProduct(GameObject obj)
    {
        obj.SetActive(false);
        productPool.Enqueue(obj);
    }
}

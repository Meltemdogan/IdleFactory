using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class Machine : MonoBehaviour
{
    [SerializeField] private Transform StartPoint; 
    [SerializeField] private Transform EndPoint;
    private Vector3 ConveyorEndPoint = new Vector3(0.01f, 1.08f, -4.02f);
    public MachineData machineData;
    private bool isRunning = true;

    public void Initialize(Transform mainConvEndPoint)
    {
        ConveyorEndPoint = mainConvEndPoint.position;
    }
    
    public void Start()
    {
        StartCoroutine(GenerateCode());
    }
    
    IEnumerator GenerateCode()
    {
        while (isRunning)
        {
            var cooldown = 1f / machineData.productionSpeed;
            yield return new WaitForSeconds(cooldown);
            ProduceProduct();
        }
    }
    
    private void ProduceProduct()
    {
        EndPoint.position = new Vector3(EndPoint.position.x, EndPoint.position.y, Random.Range(29.8f, 31f));
        GameObject product = ProductPool.Instance.GetProduct(machineData.productData ,StartPoint.position);
        product.GetComponent<ProductMovement>().Initialize(StartPoint.position, EndPoint.position, ConveyorEndPoint, machineData.productData, ProductPool.Instance);
        FactoryStorage.Instance.AddProduct(machineData.productData);
    }
}
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;


public class ProductMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 conveyorEndPosition;
    private ProductPool pool;
    private bool isTurning;
    
    private void OnEnable()
    {
        isTurning = false;
    }
    
    public void Initialize(Vector3 start, Vector3 end, Vector3 conveyorEnd, ProductPool objectPool)
    {
        startPosition = start;
        endPosition = end;
        conveyorEndPosition = conveyorEnd;
        pool = objectPool;
    }
    
    private void Update()
    {
        if (!isTurning)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, endPosition) < 0.1f)
            {
                isTurning = true;
            }
        }
        else
        {
            var _endPosition = new Vector3(conveyorEndPosition.x, conveyorEndPosition.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, _endPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _endPosition) < 0.1f)
            {
                pool.ReturnProduct(gameObject.GetComponent<ProductData>(), gameObject);
            }
        } 
    }
}
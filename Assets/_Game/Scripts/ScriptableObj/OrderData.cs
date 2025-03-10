using UnityEngine;

[CreateAssetMenu(fileName = "OrderData", menuName = "Factory/Order")]
public class OrderData : ScriptableObject
{
   public string orderName;
   public ProductData requestedProduct;
   public int quantity;
   public float timeLimit;
   public int reward;
}

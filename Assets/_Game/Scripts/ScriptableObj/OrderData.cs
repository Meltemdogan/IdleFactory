using UnityEngine;

[CreateAssetMenu(fileName = "OrderData", menuName = "Factory/Order")]
public class OrderData : ScriptableObject
{
   public ProductData product;
   public int quantity;
   public int reward;
}

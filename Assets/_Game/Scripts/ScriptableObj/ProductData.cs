using UnityEngine;

[CreateAssetMenu(fileName = "ProductData", menuName = "Factory/Product")]
public class ProductData : ScriptableObject
{
    public string productName;
    public Sprite productIkon;
    public float productionTime;
    public int basePrice;
}

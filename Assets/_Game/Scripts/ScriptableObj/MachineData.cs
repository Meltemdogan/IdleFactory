using UnityEngine;

[CreateAssetMenu(fileName = "MachineData", menuName = "Factory/Machine")]
public class MachineData : ScriptableObject
{
    public string machineName;
    public Sprite machineIcon;
    public GameObject Product;
    public ProductData producesProduct; 
    public int price; 
    public float productionSpeed;
}

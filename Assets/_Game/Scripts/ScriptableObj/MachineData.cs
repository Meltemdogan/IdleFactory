using UnityEngine;

[CreateAssetMenu(fileName = "MachineData", menuName = "Factory/Machine")]
public class MachineData : ScriptableObject
{
    public string machineName;
    public Sprite machineIcon;
    public GameObject machinePrefab;
    public ProductData productData;
    public int price; 
    public float productionSpeed;
}

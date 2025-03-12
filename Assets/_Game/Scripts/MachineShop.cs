using Unity.VisualScripting;
using UnityEngine;

public class MachineShop : MonoBehaviour
{
    public MachineData machineToBuy;
    public Transform machineParent;
    public Transform[] spawnPoints;
    
    public void BuyMachine(MachineData machineData, int machineIndex)
    {
        if(PlayerEconomy.Instance.currentMoney >= machineToBuy.price)
        {
            PlayerEconomy.Instance.SpendMoney(machineToBuy.price);
            
            Transform spawnPoint = spawnPoints[machineIndex];
            
            GameObject machineObj = Instantiate(machineData.machinePrefab, spawnPoint.position, Quaternion.identity);
            Machine newMachine = machineObj.GetComponent<Machine>(); 
            
            GameManager.Instance.RegisterMachine(newMachine);
        }
        else
        {
            Debug.Log("Not enough money to buy this machine");
        }
    }
}

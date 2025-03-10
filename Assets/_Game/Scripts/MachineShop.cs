using Unity.VisualScripting;
using UnityEngine;

public class MachineShop : MonoBehaviour
{
    public MachineData machineToBuy;
    public Transform machineParent;
    
    public void BuyMachine()
    {
        if(PlayerEconomy.Instance.currentMoney >= machineToBuy.price)
        {
            PlayerEconomy.Instance.SpendMoney(machineToBuy.price);
            GameObject machineObj = new GameObject(machineToBuy.machineName);
            Machine newMachine = machineObj.AddComponent<Machine>();
            newMachine.machineData = machineToBuy;
            
            GameManager.Instance.RegisterMachine(newMachine);
        }
        else
        {
            Debug.Log("Not enough money to buy this machine");
        }
    }
}

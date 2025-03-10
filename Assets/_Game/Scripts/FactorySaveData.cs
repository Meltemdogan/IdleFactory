using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FactorySaveData : MonoBehaviour
{
   public int money;
   public List<string> ownedMachines;
   public List<string> storedProducts;
   public List<string> activeOrders;
}

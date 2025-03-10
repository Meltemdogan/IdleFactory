using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLevelManager : MonoBehaviour
{
   public static PlayerLevelManager Instance;
   public int currentLevel;
   public int currentXP;
   public int xpToNextLevel;
   
   public TMP_Text levelText;
   public Slider XPBar;
   
   public List<LevelData> levelData;
   
   private void Awake()
   {
         if(Instance == null) Instance = this;
         else Destroy(gameObject);
   }
   
   private void Start()
   {
      UpdateUI();
   }
   
   public void GainXP(int amount)
   {
      currentXP = levelData[currentLevel].GetXPToNextLevel();
      currentXP += amount;
      if (currentXP >= xpToNextLevel)
      {
         currentXP -= xpToNextLevel;
         currentLevel++;
         xpToNextLevel = currentLevel * 100;
      }
   }
   
   private void UpdateUI()
   {
     levelText.text = "Level: " + currentLevel;
     XPBar.value = (float)currentXP / xpToNextLevel;
   }
}


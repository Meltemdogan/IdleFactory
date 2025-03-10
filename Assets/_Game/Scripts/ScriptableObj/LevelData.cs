using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Level/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public int level;
    public List<int> xpTable;
    
    public int GetXPToNextLevel()
    {
        if (level < xpTable.Count)
        {
            return xpTable[level];
        }
        else
        {
            return 0;
        }
    }
    public void LevelUp()
    {
        if (level  < xpTable.Count - 1)
        {
            level++;
        }
        
    }
}

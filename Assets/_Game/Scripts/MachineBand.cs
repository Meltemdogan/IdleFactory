using System;
using UnityEngine;

public class MachineBand : MonoBehaviour
{
    [SerializeField] private Material bandMaterial;
    [SerializeField] private float speed = 1f;
    
    void Update()
    {
        ShiftBand();
    }
    public void ShiftBand()
    {
        bandMaterial.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}

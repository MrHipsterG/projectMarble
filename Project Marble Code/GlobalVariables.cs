using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {

    public enum TOOL
    {
        CHISEL,HAMMER,BUSTER
    }

    // Menu
    public bool menuActive;

    // CubeGen
    public float[] bCubeScaleStages = new float[]
    {
        0.5f,0.2f,0.1f
    };
    public int BreakableCubeColors = 7;
    public float bCubeScale = 0.5f;
    public int cubeDifficulty = 0;


    // BCubeBehaviour
    public float CubeHealth = 1;
    public int ChiselDamage = 1;
    public int HammerDamage = 1;
    public int BusterDamage = 1;
    public TOOL currentTool = TOOL.CHISEL;

    // ScoreCounter
    public float ChiselReward = 1;
    public float HammerReward = 1;
    public float BusterReward = 1;
    public float tiksPerLayer = 10;
    public float rewardMultiplier = 1;
    public float tiksPerSecond;

    // Tools
    public bool UnlockedHammer;
    public bool UnlockedBuster;

    public float ChiselUpgradeCost = 500;
    public float HammerUpgradeCost = 1000;
    public float BusterUpgradeCost = 10000;

    public float ChiselUpgradeCostMultiplier = 5.5f;
    public float HammerUpgradeCostMultiplier = 5.8f;
    public float BusterUpgradeCostMultiplier = 6.2f;

    public int HammerUses = 0;
    public int BusterUses = 0;

    public int HammerUsesPerPurchase = 20;
    public int BusterUsesPerPurchase = 1;

    public float HammerUsesCost = 50;
    public float BusterUsesCost = 500;

    public float HammerUsesCostMultiplier = 1.2f;
    public float BusterUsesCostMultiplier = 2f;

    // Statistics
    public float Playtime = -30;
    public float allscore;
    public int GoldCubes;
    public int Ascends;
    public int LayersCleared;
    public int AscendReward;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        Playtime += Time.deltaTime;

        if (HammerUses == 0)
        {
            UnlockedHammer = false;
        }
        else
        {
            UnlockedHammer = true;
        }
        if (BusterUses == 0)
        {
            UnlockedBuster = false;
        }
        else
        {
            UnlockedBuster = true;
        }
    }
}

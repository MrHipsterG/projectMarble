using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseHandler : MonoBehaviour {

    GlobalVariables GV;
    ScoreCounter score;

    private void Start()
    {
        GV = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalVariables>();
        score = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreCounter>();
    }

    public bool BuyUses(GlobalVariables.TOOL tool)
    {
        if (tool == GlobalVariables.TOOL.HAMMER)
        {
            if (score.score >= GV.HammerUsesCost)
            {
                score.BuyObject(GV.HammerUsesCost);
                GV.HammerUses += 20;
                return true;
            }
            return false;
        }
        if (tool == GlobalVariables.TOOL.BUSTER)
        {
            if (score.score >= GV.BusterUsesCost)
            {
                score.BuyObject(GV.BusterUsesCost);
                GV.BusterUses += 1;
                return true;
            }
            return false;
        }
        return false;
    }

    public bool BuyUpgrade(GlobalVariables.TOOL tool)
    {
        if (tool == GlobalVariables.TOOL.CHISEL)
        {
            if (score.score >= GV.ChiselUpgradeCost)
            {
                score.BuyObject(GV.ChiselUpgradeCost);
                GV.ChiselDamage += 1;
                GV.ChiselUpgradeCost *= GV.ChiselUpgradeCostMultiplier;
                return true;
            }
            return false;
        }
        if (tool == GlobalVariables.TOOL.HAMMER)
        {
            if (score.score >= GV.HammerUpgradeCost)
            {
                score.BuyObject(GV.HammerUpgradeCost);
                GV.HammerDamage += 1;
                GV.HammerUses = 0;
                GV.HammerUpgradeCost *= GV.HammerUpgradeCostMultiplier;
                GV.HammerUsesCost *= GV.HammerUsesCostMultiplier;
                return true;
            }
            return false;
        }
        if (tool == GlobalVariables.TOOL.BUSTER)
        {
            if (score.score >= GV.BusterUpgradeCost)
            {
                score.BuyObject(GV.BusterUpgradeCost);
                GV.BusterDamage += 1;
                GV.BusterUses = 0;
                GV.BusterUpgradeCost *= GV.BusterUpgradeCostMultiplier;
                GV.BusterUsesCost *= GV.HammerUsesCostMultiplier;
            }
            return false;
        }
        return false;
    }

}

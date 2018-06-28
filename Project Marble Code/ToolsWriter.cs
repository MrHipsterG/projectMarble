using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolsWriter : MonoBehaviour {

    GlobalVariables GV;
    ScoreCounter score;

    Text ChiselDamageCount;
    Text UpgradeChiselCost;
    Text HammerUsesCount;
    Text HammerDamageCount;
    Text UpgradeHammerCost;
    Text BuyUsesHammerCost;
    Text BusterUsesCount;
    Text BusterDamageCount;
    Text UpgradeBusterCost;
    Text BuyUsesBusterCost;


    void Start () {
        GV = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalVariables>();
        score = GV.GetComponent<ScoreCounter>();
        ChiselDamageCount = GameObject.Find("ChiselDamageCount").GetComponent<Text>();
        UpgradeChiselCost = GameObject.Find("UpgradeChiselCost").GetComponent<Text>();
        HammerUsesCount = GameObject.Find("HammerUsesCount").GetComponent<Text>();
        HammerDamageCount = GameObject.Find("HammerDamageCount").GetComponent<Text>();
        UpgradeHammerCost = GameObject.Find("UpgradeHammerCost").GetComponent<Text>();
        BuyUsesHammerCost = GameObject.Find("BuyUsesHammerCost").GetComponent<Text>();
        BusterUsesCount = GameObject.Find("BusterUsesCount").GetComponent<Text>();
        BusterDamageCount = GameObject.Find("BusterDamageCount").GetComponent<Text>();
        UpgradeBusterCost = GameObject.Find("UpgradeBusterCost").GetComponent<Text>();
        BuyUsesBusterCost = GameObject.Find("BuyUsesBusterCost").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        ChiselDamageCount.text = score.ConvertToDisplayable(GV.ChiselDamage);
        UpgradeChiselCost.text = score.ConvertToDisplayable(GV.ChiselUpgradeCost);
        HammerUsesCount.text = score.ConvertToDisplayable(GV.HammerUses);
        HammerDamageCount.text = score.ConvertToDisplayable(GV.HammerDamage);
        UpgradeHammerCost.text = score.ConvertToDisplayable(GV.HammerUpgradeCost);
        BuyUsesHammerCost.text = score.ConvertToDisplayable(GV.HammerUsesCost);
        BusterUsesCount.text = score.ConvertToDisplayable(GV.BusterUses);
        BusterDamageCount.text = score.ConvertToDisplayable(GV.BusterDamage);
        UpgradeBusterCost.text = score.ConvertToDisplayable(GV.BusterUpgradeCost);
        BuyUsesBusterCost.text = score.ConvertToDisplayable(GV.BusterUsesCost);
    }
}

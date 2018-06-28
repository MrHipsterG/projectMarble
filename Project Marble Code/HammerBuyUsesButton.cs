using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerBuyUsesButton : MonoBehaviour {

    GlobalVariables GV;
    PurchaseHandler buy;
    Button btn;

    private void Awake()
    {
        GV = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalVariables>();
        buy = GameObject.FindGameObjectWithTag("GameController").GetComponent<PurchaseHandler>();
        btn = this.GetComponent<Button>();
    }

    private void Start()
    {
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        buy.BuyUses(GlobalVariables.TOOL.HAMMER);
    }
}

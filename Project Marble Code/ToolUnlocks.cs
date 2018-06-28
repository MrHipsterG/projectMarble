using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolUnlocks : MonoBehaviour {

    GlobalVariables GV;

	void Start () {
        GV = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalVariables>();
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Transform tool in transform)
        {
            if (tool.gameObject.name.Equals("ChiselButton"))
            {
                if (GV.currentTool != GlobalVariables.TOOL.CHISEL)
                {
                    tool.GetComponent<Button>().interactable = true;
                }
                else
                {
                    tool.GetComponent<Button>().interactable = false;
                }
            }
            if (tool.gameObject.name.Equals("HammerButton"))
            {
                if (GV.currentTool != GlobalVariables.TOOL.HAMMER)
                {
                    tool.GetComponent<Button>().interactable = GV.UnlockedHammer;
                }
                else
                {
                    tool.GetComponent<Button>().interactable = false;
                }
            }
            if (tool.gameObject.name.Equals("BusterButton"))
            {
                if (GV.currentTool != GlobalVariables.TOOL.BUSTER)
                {
                    tool.GetComponent<Button>().interactable = GV.UnlockedBuster;
                }
                else
                {
                    tool.GetComponent<Button>().interactable = false;
                }
            }
        }
    }
}

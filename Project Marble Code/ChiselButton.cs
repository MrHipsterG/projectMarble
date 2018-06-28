using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChiselButton : MonoBehaviour {

    GlobalVariables GV;
    Button btn;
    Transform SelectableTools;

    private void Awake()
    {
        GV = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalVariables>();
        btn = this.GetComponent<Button>();
        SelectableTools = GameObject.Find("SelectableTools").transform;
    }

    private void Start()
    {
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        foreach (Transform tool in SelectableTools)
        {
            tool.GetComponent<Button>().interactable = true;
        }
        GV.currentTool = GlobalVariables.TOOL.CHISEL;
        btn.interactable = false;
    }
}

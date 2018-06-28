using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerButton : MonoBehaviour {
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

    void TaskOnClick()
    {
        foreach (Transform tool in SelectableTools)
        {
            tool.GetComponent<Button>().interactable = true;
        }
        GV.currentTool = GlobalVariables.TOOL.HAMMER;
        btn.interactable = false;
    }
}

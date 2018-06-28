using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesButton : MonoBehaviour {
    MenuAnchorController menu;
    Button btn;

    private void Awake()
    {
        btn = this.GetComponent<Button>();
    }

    private void Start()
    {
        btn.onClick.AddListener(TaskOnClick);
        menu = GameObject.FindGameObjectWithTag("MenuAnchor").GetComponent<MenuAnchorController>();
    }

    void TaskOnClick()
    {
        menu.SwitchTo(-1000);
    }

}

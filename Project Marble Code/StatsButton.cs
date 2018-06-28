using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsButton : MonoBehaviour {
    MenuAnchorController menu;
    Button btn;

    private void Awake()
    {
        btn = this.GetComponent<Button>();
    }

    private void Start()
    {
        menu = GameObject.FindGameObjectWithTag("MenuAnchor").GetComponent<MenuAnchorController>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        menu.SwitchTo(1000);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {

    Button btn;
    GameObject rotationPanel;
    RectTransform menuPanel;
    GlobalVariables GV;

    Vector3 desiredPosition;
    Vector3 startingPosition;
    private void Awake()
    {
        GV = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalVariables>();
        btn = this.GetComponent<Button>();
        rotationPanel = GameObject.FindGameObjectWithTag("RotationPanel");
        menuPanel = GameObject.FindGameObjectWithTag("MenuPanel").GetComponent<RectTransform>();
    }
    void Start()
    {
        btn.onClick.AddListener(TaskOnClick);
        startingPosition = menuPanel.position;
        desiredPosition = startingPosition;
    }

    void TaskOnClick()
    {
        GV.menuActive = !GV.menuActive;
        rotationPanel.SetActive(!GV.menuActive);
        if (GV.menuActive)
        {
            desiredPosition = new Vector3(startingPosition.x, startingPosition.y + 1000);
            
        }
        else
        {
            desiredPosition = startingPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        menuPanel.position = Vector3.Lerp(menuPanel.position, desiredPosition, Time.deltaTime * 5);
    }
}

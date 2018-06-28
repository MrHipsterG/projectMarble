using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInputs : MonoBehaviour {

    BCubeGenerate cubegen;
    CameraControls cmr;
    Transform Ccube;
    GlobalVariables GV;
    ScoreCounter score;

    // Use this for initialization
    void Start () {
        GV = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalVariables>();
        score = GV.GetComponent<ScoreCounter>();
        cubegen = GameObject.FindGameObjectWithTag("CenterCube").GetComponent<BCubeGenerate>();
        cmr = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControls>();
        Ccube = cubegen.Ccube;
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.F))
        {
            Screen.fullScreen = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            cubegen.RemoveCubes();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GV.bCubeScale = 0.2f;
            cubegen.GenerateFullCube();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GV.bCubeScale = 0.1f;
            cubegen.GenerateFullCube();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GV.bCubeScale = 0.05f;
            cubegen.GenerateFullCube();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach (Transform cube in Ccube)
            {
                score.SetScore(5000);
            }
        }
    }
}

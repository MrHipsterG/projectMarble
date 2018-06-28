using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCubeGenerate : MonoBehaviour {

    public GameObject BreakableCube;
    CameraControls cmr;
    public Transform Ccube;
    GlobalVariables GV;
    ScoreCounter score;

    float CcubeScale;

    int amountOfBCubes;


    GameObject[] cubes;

    private void Awake()
    {
        GV = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalVariables>();
        cmr = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControls>();
        score = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreCounter>();
        Ccube = this.transform;
        CcubeScale = Ccube.localScale.x;
    }

    void Start () {
        UpdateBCubeScale();
        GenerateFullCube();
    }
    private void Update()
    {
        if (CheckIfLastcube())
        {
            DoNewLayer();
        }
    }

    public void DoNewLayer()
    {
        if (GV.cubeDifficulty == GV.bCubeScaleStages.Length - 1)
        {
            GV.cubeDifficulty = -1;
            GV.CubeHealth += 1;
            if (GV.CubeHealth > GV.BreakableCubeColors)
            {
                GV.CubeHealth = GV.BreakableCubeColors;
            }
            GV.rewardMultiplier *= 1.5f;
        }
        GV.LayersCleared++;
        GV.cubeDifficulty++;
        GV.bCubeScale = GV.bCubeScaleStages[GV.cubeDifficulty];
        UpdateBCubeScale();
        RemoveCubes();
        GenerateFullCube();
        GV.tiksPerLayer = 100 * GV.rewardMultiplier;
        score.AddScore(GV.tiksPerLayer);
    }

    public void UpdateBCubeScale()
    {
        float BCubeScale = GV.bCubeScale;
        BreakableCube.transform.localScale = new Vector3(BCubeScale, BCubeScale, BCubeScale);
        amountOfBCubes = Convert.ToInt32(((CcubeScale / BCubeScale) * (CcubeScale / BCubeScale) + (((CcubeScale / BCubeScale) + 1) * 4) * 6));
        cubes = new GameObject[amountOfBCubes];
    }

    public bool CheckIfLastcube()
    {
        int CubesLeft = 0;
        foreach (Transform cube in transform)
        {
            if (cube.gameObject.CompareTag("BreakableCube"))
            {
                CubesLeft++;
            }
        }
        if (CubesLeft == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    public void RemoveCubes()
    {
        foreach (Transform cube in Ccube)
        {
            GameObject.Destroy(cube.gameObject);
        }
    }

    public void GenerateFullCube()
    {
        //Camera
        cmr.SetNewMinMaxDistance(cmr.standardMinDistance - (GV.bCubeScale * 6) , cmr.standardMaxDistance - (GV.bCubeScale * 6));
        cmr.ZoomCameraNewCube((GV.bCubeScale));
        //Generation
        GenerateCubes();
    }

    void GenerateCubes()
    {
        // This is a lot better than it used to be now.

        int BlocksPerRow = Convert.ToInt32((CcubeScale / GV.bCubeScale) + 2);

        //Depth
        for (int i = 0; i < BlocksPerRow; i++)
        {
            if (i == 0 || i == BlocksPerRow - 1)
            {
                for (int j = 0; j < BlocksPerRow; j++)
                {
                    for (int k = 0; k < BlocksPerRow; k++)
                    {
                        GenerateSingleCube(i, j, k);
                    }
                }
            }
            else
            {
                //Columns inbetween 0 and max
                for (int j = 0; j < BlocksPerRow; j++)
                {
                    if (j == 0 || j == BlocksPerRow-1)
                    {
                        //rows inbetween 0 and max
                        for (int k = 0; k < BlocksPerRow; k++)
                        {
                            GenerateSingleCube(i, j, k);
                        }
                    }
                    else
                    {
                        //Rows 0 or max
                        for (int k = 0; k < BlocksPerRow; k++)
                        {
                            if (k == 0 || k == BlocksPerRow - 1)
                            {
                                GenerateSingleCube(i, j, k);
                            }
                        }
                    }
                }
            }
        }
    }

    void GenerateSingleCube(int i, int j, int k)
        {
           Vector3 DesiredPosition = new Vector3(-(CcubeScale / 2 + GV.bCubeScale / 2) + (GV.bCubeScale * i), -(CcubeScale / 2 + GV.bCubeScale / 2) + (GV.bCubeScale * j), -(CcubeScale / 2 + GV.bCubeScale / 2) + (GV.bCubeScale * k));

           cubes[i] = Instantiate(BreakableCube, DesiredPosition, Ccube.rotation);
           cubes[i].transform.parent = transform;
           cubes[i].transform.localPosition = DesiredPosition;
           cubes[i].name = "BreakableCube " + i + "-" + j + "-" + k;
        }
    }

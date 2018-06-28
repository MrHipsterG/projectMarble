using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableCubeBehaviour : MonoBehaviour {

    public GameObject obj;
    public ScoreCounter score;
    GlobalVariables GV;
    BCubeGenerate Cubegen;
    ParticleSystem particle;
    ParticleSystemRenderer particlerender;

    float CubeHealth;
    float CubeStageHealth;

    public Material CubeMaterial;

    public Material CubeRed;
    public Material CubeOrange;
    public Material CubeYellow;
    public Material CubeGreen;
    public Material CubeBlue;
    public Material CubePurple;
    public Material CubeWhite;

    // Use this for initialization
    void Start()
    {
        GV = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalVariables>();
        Cubegen = GameObject.FindGameObjectWithTag("CenterCube").GetComponent<BCubeGenerate>();

        CubeHealth = GV.CubeHealth;

        obj = this.gameObject;
        score = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreCounter>();
        particle = this.GetComponentInChildren<ParticleSystem>();
        particlerender = this.GetComponentInChildren<ParticleSystemRenderer>();
        ApplyColor(GV.BreakableCubeColors);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !GV.menuActive)
        {
            onTap();
        }
    }

    void onTap()
    {
        if (GV.currentTool == GlobalVariables.TOOL.CHISEL)
        {
            DamageCube(GV.ChiselDamage,GV.ChiselReward);
        }
        if (GV.currentTool == GlobalVariables.TOOL.HAMMER)
        {
            if (GV.HammerUses > 0)
            {
                GV.HammerUses -= 1;
                Collider[] hitBcubes = Physics.OverlapSphere(transform.position, GV.bCubeScale);
                foreach (Collider col in hitBcubes)
                {
                    if (col.gameObject.CompareTag("BreakableCube"))
                    {
                        col.GetComponent<BreakableCubeBehaviour>().DamageCube(GV.HammerDamage, GV.HammerReward);
                    }
                }
                hitBcubes = Physics.OverlapSphere(transform.position, GV.bCubeScale*2);
                foreach (Collider col in hitBcubes)
                {
                    if (col.gameObject.CompareTag("BreakableCube"))
                    {
                        
                        col.GetComponent<BreakableCubeBehaviour>().DamageCube(GV.HammerDamage, GV.HammerReward);
                    }
                }
            }
            else
            {
                // Notify that you're out of uses with a noise maybe?
                GV.currentTool = GlobalVariables.TOOL.CHISEL;
            }
        }
        if (GV.currentTool == GlobalVariables.TOOL.BUSTER)
        {
            if (GV.BusterUses > 0)
            {
                GV.BusterUses -= 1;
                foreach (Transform cube in Cubegen.transform)
                {
                    if (cube.gameObject.CompareTag("BreakableCube"))
                    {
                        cube.GetComponent<BreakableCubeBehaviour>().DamageCube(GV.BusterDamage, GV.BusterReward);
                    }
                }
            }
            else
            {
                // Notify that you're out of uses with a noise maybe?
                GV.currentTool = GlobalVariables.TOOL.CHISEL;
            }
        }
    }

    void DamageCube(int DamageValue,float Reward)
    {
        particlerender.material = CubeMaterial;
        // Damage
        CubeHealth -= DamageValue;
        if (CubeHealth <= 0)
        {
            particle.transform.parent = null;
            particle.Emit(10);
            score.AddScore(Reward * GV.rewardMultiplier);
            DestroyCube();
        }
        ApplyColor(Convert.ToInt32(CubeHealth));
    }

    void DestroyCube()
    {
        Destroy(obj);
    }

    void ApplyColor(int Stage)
    {
        switch (Stage)
        {
            case 7:
                CubeMaterial = CubeWhite;
                break;
            case 6:
                CubeMaterial = CubePurple;
                break;
            case 5:
                CubeMaterial = CubeBlue;
                break;
            case 4:
                CubeMaterial = CubeGreen;
                break;
            case 3:
                CubeMaterial = CubeYellow;
                break;
            case 2:
                CubeMaterial = CubeOrange;
                break;
            case 1:
            default:
                CubeMaterial = CubeRed;
                break;
        }
        this.GetComponent<Renderer>().material = CubeMaterial;
    }
}

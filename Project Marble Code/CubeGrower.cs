using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGrower : MonoBehaviour {

    public Transform Ccube;
    public Transform Bcube;

    public float standardSize;
    public float growAmount;

	void Start () {
        Ccube = this.gameObject.transform;
        standardSize = Ccube.localScale.x;
        growAmount = Bcube.localScale.x / 6;
	}
	
    public void Grow()
    {
        this.gameObject.transform.localScale.Set(Ccube.localScale.x+growAmount, Ccube.localScale.y + growAmount, Ccube.localScale.z + growAmount);
        Debug.Log("Grown to:" + this.gameObject.transform.localScale.x);
    }
}

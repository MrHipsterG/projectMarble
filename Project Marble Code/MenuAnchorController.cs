using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnchorController : MonoBehaviour {

    Vector3 desiredPosition = Vector3.zero;

    public void SwitchTo(int xPos)
    {
        desiredPosition = new Vector3(xPos, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, desiredPosition, Time.deltaTime * 8);
	}
}

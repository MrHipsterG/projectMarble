using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {
    Transform cmr;
    Vector3 newPosition;
    GlobalVariables GV;
    public float standardMinDistance;
    public float standardMaxDistance;

    public float minDistance;
    public float maxDistance;

    private void Awake()
    {
        GV = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalVariables>();
        cmr = this.transform;
        minDistance = standardMinDistance;
        maxDistance = standardMaxDistance;
        newPosition = cmr.position;
    }

    void Start()
    {
        
    }

    void Update()
    {
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheelInput != 0f)
        {
            ZoomCameraHarsh(new Vector3(cmr.position.x, cmr.position.y, cmr.position.z + scrollWheelInput));
        }
        if (cmr.position.z > maxDistance)
        {
            newPosition.z = maxDistance;
            ZoomCameraHarsh(newPosition);
        }
        if (cmr.position.z < minDistance)
        {
            newPosition.z = minDistance;
            ZoomCameraSmooth(newPosition);
        }
        
    }

    public void ZoomCameraNewCube(float cubeScale)
    {
        ZoomCameraHarsh(new Vector3(cmr.position.x, cmr.position.y, cmr.position.z - cubeScale * (cmr.position.z * -2)));
    }
    public void ZoomCameraHarsh(Vector3 newPosition)
    {
        this.transform.SetPositionAndRotation(newPosition, cmr.rotation);
    }
    public void ZoomCameraSmooth(Vector3 newPosition)
    {
        this.transform.SetPositionAndRotation(Vector3.Lerp(cmr.position, newPosition,Time.deltaTime*2), cmr.rotation);
    }

    public void SetNewMinMaxDistance(float minDistance, float maxDistance)
    {
        this.minDistance = minDistance;
        this.maxDistance = maxDistance;
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class CenterCubeRotation : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public GameObject Ccube;
    public float rotSpeed = 15f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        Ccube.transform.RotateAround(Vector3.up, -rotX);
        Ccube.transform.RotateAround(Vector3.right, rotY);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //throw new NotImplementedException();
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class BaseRotation : MonoBehaviour, IPointerClickHandler,IPointerUpHandler,IDragHandler {

    [SerializeField]
    private GameObject rotateObject;
    [SerializeField]
    private float RotationSpeed;




    public void OnDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}

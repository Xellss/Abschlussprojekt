using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class BaseRotation : MonoBehaviour, IDragHandler,IDropHandler
{

    [SerializeField]
    private float RotationSpeed = 1;
    GameObject ground;

    void Awake()
    {
        ground = GameObject.Find("Ground");
    }

    public void OnDrag(PointerEventData eventData)
    {
        ground.layer = LayerMask.NameToLayer("Default");
        Vector2 position = eventData.position;
        Vector2 oldPosition = position - eventData.delta;
        Vector2 center = Camera.main.WorldToScreenPoint(Vector3.zero);
        Vector2 direction = position-center;
        Vector2 oldDirection = oldPosition-center;
        var v = Vector2.Angle(oldDirection, direction);
        if (Vector3.Cross(direction,oldDirection).z <0)
            v = -v;

        transform.Rotate(0, v * RotationSpeed, 0, Space.Self);
    }

    public void OnDrop(PointerEventData eventData)
    {
        ground.layer = LayerMask.NameToLayer("Ground");

    }
}

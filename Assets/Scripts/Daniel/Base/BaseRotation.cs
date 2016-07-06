/////////////////////////////////////////////////
/////////////////////////////////////////////////
using System;
using System.Collections;
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseRotation : MonoBehaviour, IDragHandler, IDropHandler, IBeginDragHandler, IEndDragHandler
{
    private GameObject ground;
    [SerializeField]
    private float RotationSpeed = 1;
    private float delta;

    private float rotation;
    public void OnBeginDrag(PointerEventData eventData)
    {
        StopCoroutine("endinertia");
        delta = 0;
    }

    public void OnDrag(PointerEventData eventData)
    {
        delta += eventData.delta.magnitude;

        if (delta <= 10)
        {
            return;
        }
        ground.layer = LayerMask.NameToLayer("Default");
        Vector2 position = eventData.position;
        Vector2 oldPosition = position - eventData.delta;
        Vector2 center = Camera.main.WorldToScreenPoint(Vector3.zero);
        Vector2 direction = position - center;
        Vector2 oldDirection = oldPosition - center;
        rotation = Vector2.Angle(oldDirection, direction);
        rotation = Mathf.Clamp(rotation, 0, 2.5f);
        if (Vector3.Cross(direction, oldDirection).z < 0)
            rotation = -rotation;

        transform.Rotate(0, rotation * RotationSpeed * Time.deltaTime, 0, Space.Self);
    }

    public void OnDrop(PointerEventData eventData)
    {
        ground.layer = LayerMask.NameToLayer("Ground");
    }

    private void Awake()
    {
        ground = GameObject.Find("Ground");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (delta <= 10)
        {
            return;
        }
        StartCoroutine("endinertia");
    }

    private IEnumerator endinertia()
    {
        while (Mathf.Abs(rotation) > 0.05)
        {
            transform.Rotate(0, rotation * RotationSpeed * Time.deltaTime, 0, Space.Self);
            rotation *= 0.75f;
            yield return null;
        }
    }
}

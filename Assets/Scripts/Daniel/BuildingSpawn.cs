using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingSpawn : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    private RaycastHit hit;

    private bool buildingPlaced = false;

    public bool BuildingPlaced
    {
        get { return buildingPlaced; }
        set { buildingPlaced = value; }
    }

    private GameObject buildingPrefab;

    public GameObject BuildingPrefab
    {
        get { return buildingPrefab; }
        set { buildingPrefab = value; }
    }






    private BuildingInformation buildingInformation;

    public BuildingInformation BuildingInformation
    {
        get { return buildingInformation; }
        set { buildingInformation = value; }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        Physics.Raycast(ray, out hit);
        buildingPrefab.transform.position = hit.point;

        Debug.Log(hit.point);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        Physics.Raycast(ray, out hit);

        if (hit.transform.gameObject.layer ==  buildingPrefab.layer && !buildingPlaced)
        {
            print("treffer");
        }

        Debug.Log(hit.point);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
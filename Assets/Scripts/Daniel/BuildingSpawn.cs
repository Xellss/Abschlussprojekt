using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{
    private RaycastHit hit;
    public GameObject grabObject;

    private bool buildingPlaced = false;
    private bool grab = false;

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

    private void Start()
    { }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (buildingPrefab != null)
            {
                if (hit.transform.gameObject.layer == buildingPrefab.layer && !grab)
                {
                    grabObject = hit.transform.gameObject;
                    grab = true;
                }
                if (grab)
                    grabObject.transform.position = new Vector3(hit.point.x, 0f, hit.point.z);
            }
        }
        else
            grab = false;
    }
  
}
using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{
    private RaycastHit hit;
    private GameObject grabObject;

    private bool grab = false;


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

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.transform != null)
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("NewBuilding") && !grab)
                {
                    grabObject = hit.transform.gameObject;
                    grab = true;
                }
                if (grab)
                    grabObject.transform.position = new Vector3(Mathf.Round( hit.point.x), 0f,Mathf.Round( hit.point.z));
            }
            }
        else
            grab = false;
        
    }
  
}
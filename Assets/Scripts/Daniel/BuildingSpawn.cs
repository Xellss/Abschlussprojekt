/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{
    private BuildingInformation buildingInformation;
    private GameObject buildingPrefab;
    private bool grab = false;
    private GameObject grabObject;
    private RaycastHit hit;
    private GameObject loseScreen;

    public BuildingInformation BuildingInformation
    {
        get { return buildingInformation; }
        set { buildingInformation = value; }
    }

    public GameObject BuildingPrefab
    {
        get { return buildingPrefab; }
        set { buildingPrefab = value; }
    }

    void Awake()
    {
        loseScreen = GameObject.Find("Lose_Image");
        loseScreen.SetActive(false);
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
                    grabObject.transform.position = new Vector3(Mathf.Round(hit.point.x), 0f, Mathf.Round(hit.point.z));
            }
        }
        else
            grab = false;
    }
}

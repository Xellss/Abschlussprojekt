using UnityEngine;

public class ShopButtonBehaviour : MonoBehaviour
{
    private GameObject newBuilding;
    private GameObject buildButton;
    private BuildingInformation buildingInformation;
    private GameObject shopButton;
    private GameObject shop;

    private void Awake()
    {
        gameObject.GetComponent<BuildingSpawn>();
        shopButton = transform.FindChild("ShopButton").gameObject;
        shop = transform.FindChild("Shop").gameObject;
    }

    public void OnClickShopCard(BuildingSpawn buildingSpawn, BuildingInformation cardInformation, GameObject buildButton)
    {
        buildingInformation = cardInformation;
        this.buildButton = buildButton;
        transform.GetChild(0).gameObject.SetActive(false);
        newBuilding = (GameObject)Instantiate(cardInformation.BuildingPrefab, Vector3.zero, Quaternion.identity);
        newBuilding.layer = LayerMask.NameToLayer("NewBuilding");
        newBuilding.name = cardInformation.BuildingName;
        buildingSpawn.BuildingPrefab = newBuilding;
        buildingSpawn.BuildingInformation = cardInformation;
        buildButton.SetActive(true);
        
    }

    public void OnClickBuild()
    {
        newBuilding.layer = LayerMask.NameToLayer(buildingInformation.BuildingTypes.ToString());
        buildButton.SetActive(false);
        shopButton.SetActive(true);
    }

    public void OnShopClick()
    {
        shopButton.SetActive(false);
        shop.SetActive(true);
    }
}
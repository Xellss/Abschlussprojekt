using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlanetTerraforming : MonoBehaviour {

    GameState gameState;

    Text goldAmount;
    [SerializeField]
    private TerraformingPlanet terraformingPlanetScribtableObject;

    public TerraformingPlanet TerraformingPlanetScribtableObject
    {
        get { return terraformingPlanetScribtableObject; }
        set { terraformingPlanetScribtableObject = value; }
    }

    private void Awake()
    {
        gameState = GetComponent<GameState>();
        goldAmount = GameObject.Find("GoldAmount").GetComponent<Text>();
    }
    public void Terraforming(Vector3 position,Transform parentObject)
    {
       GameObject newPlanet= (GameObject)Instantiate(chosePlanetPrefab(), position, Quaternion.identity);
        newPlanet.transform.SetParent(parentObject);
    }

    private GameObject chosePlanetPrefab()
    {
        int percent = Random.Range(0, 101);

        Debug.Log(percent);
        if (percent <= terraformingPlanetScribtableObject.GasPlanetChanceInPercent)
        {
            print("Herzlichen Glückwunsch, du hast einen Gas-Planeten erschaffen. Du bekommst " + terraformingPlanetScribtableObject.GasPlanetGoldBonus + " Gold als Belohnung");
            gameState.GoldAmount += terraformingPlanetScribtableObject.GasPlanetGoldBonus;
            goldAmount.text = gameState.GoldAmount.ToString();
            return terraformingPlanetScribtableObject.GasPlanetPrefabs[Random.Range(0, terraformingPlanetScribtableObject.GasPlanetPrefabs.Length)];
        }
        else
        {
            return terraformingPlanetScribtableObject.RegularPlanetPrefabs[Random.Range(0, terraformingPlanetScribtableObject.RegularPlanetPrefabs.Length)];
        }
    }


}

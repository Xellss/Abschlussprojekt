/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;

public class PlanetTerraforming : MonoBehaviour
{
    private GameState gameState;
    private Text goldAmount;
    //PoolPrefab[] planetPrefabs;
    [SerializeField]
    private TerraformingPlanet terraformingPlanetScribtableObject;
    private bool unlockedFromBegin;
    [SerializeField]
    bool levelHavePlanets = true;

    public TerraformingPlanet TerraformingPlanetScribtableObject
    {
        get { return terraformingPlanetScribtableObject; }
        set { terraformingPlanetScribtableObject = value; }
    }

    public void Terraforming(Vector3 position, Transform parentObject, bool unlock)
    {
        if (levelHavePlanets)
        {

        unlockedFromBegin = unlock;
        GameObject newPlanet = ObjectPool.Instance.GetPooledObject(chosePlanetPrefab());
        newPlanet.transform.position = position;
        newPlanet.transform.SetParent(parentObject);
        }
    }

    private void Awake()
    {
        gameState = GetComponent<GameState>();
        goldAmount = GameObject.Find("GoldAmount").GetComponent<Text>();
    }

    private PoolPrefab chosePlanetPrefab()
    {
        int percent = Random.Range(0, 101);

        //Debug.Log(percent);
        if (percent <= terraformingPlanetScribtableObject.GasPlanetChanceInPercent)
        {
            if (!unlockedFromBegin)
            {
                print("Herzlichen Glückwunsch, du hast einen Gas-Planeten erschaffen. Du bekommst " + terraformingPlanetScribtableObject.GasPlanetGoldBonus + " Gold als Belohnung");
                gameState.GoldAmount += terraformingPlanetScribtableObject.GasPlanetGoldBonus;
                goldAmount.text = gameState.GoldAmount.ToString();
            }
            return terraformingPlanetScribtableObject.GasPlanetPrefabs[Random.Range(0, terraformingPlanetScribtableObject.GasPlanetPrefabs.Length)];
        }
        else
        {
            return terraformingPlanetScribtableObject.RegularPlanetPrefabs[Random.Range(0, terraformingPlanetScribtableObject.RegularPlanetPrefabs.Length)];
        }
    }
}

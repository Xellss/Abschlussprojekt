/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField]
    private GameObject ButtonAsteroids;
    private PlanetTerraforming planetTerraforming;
    private BaseTerrainManager terrainManager;

    public void DestroyAsteroids(bool unlock)
    {
        if (ButtonAsteroids != null)
        {
            planetTerraforming.Terraforming(transform.parent.position, ButtonAsteroids.transform.parent, unlock);
            GameObject.Destroy(ButtonAsteroids);
        }
        else
        {
        }
    }

    public void OnBuyButtonClicked()
    {
        terrainManager.UnlockTerrain();
    }

    private void Awake()
    {
        planetTerraforming = GameObject.Find("GlobalScripts").GetComponent<PlanetTerraforming>();
        terrainManager = transform.parent.GetComponent<BaseTerrainManager>();
    }
}

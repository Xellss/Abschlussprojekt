/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField]
    private GameObject ButtonAsteroids;
    private BaseTerrainManager terrainManager;

    private PlanetTerraforming planetTerraforming;

    public void OnBuyButtonClicked()
    {
        terrainManager.UnlockTerrain();
    }

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

    private void Awake()
    {
        planetTerraforming = GameObject.Find("GlobalScripts").GetComponent<PlanetTerraforming>();
        terrainManager = transform.parent.GetComponent<BaseTerrainManager>();
    }
}

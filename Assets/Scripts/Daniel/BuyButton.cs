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

    public void DestroyAsteroids()
    {
        planetTerraforming.Terraforming(ButtonAsteroids.transform.position, ButtonAsteroids.transform.parent);
        GameObject.Destroy(ButtonAsteroids);
    }

    private void Awake()
    {
        planetTerraforming = GameObject.Find("GlobalScripts").GetComponent<PlanetTerraforming>();
        terrainManager = transform.parent.GetComponent<BaseTerrainManager>();
    }
}

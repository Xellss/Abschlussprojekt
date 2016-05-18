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
    private BaseTerrainManager terrainManager;

    public void OnBuyButtonClicked()
    {
        terrainManager.UnlockTerrain();
    }

    private void Awake()
    {
        terrainManager = transform.parent.GetComponent<BaseTerrainManager>();
    }
}

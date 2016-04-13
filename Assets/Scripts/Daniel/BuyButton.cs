using UnityEngine;
using System.Collections;

public class BuyButton : MonoBehaviour {

    BaseTerrainManager terrainManager;
    void Awake()
    {
        terrainManager= transform.parent.GetComponent<BaseTerrainManager>();
    }
    public void OnBuyButtonClicked()
    {
        terrainManager.UnlockTerrain = true;
    }
}

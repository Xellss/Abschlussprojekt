using UnityEngine;
using System.Collections;

public class BaseTerrainManager : MonoBehaviour {

    [SerializeField]
    private bool unlockNewTerrain = false;

    private Renderer myRenderer;
    private GameObject buyButton;

    void Awake()
    {
        myRenderer = GetComponent<Renderer>();
        buyButton = transform.FindChild("BuyButton").gameObject;
    }

    void Update()
    {
        if (unlockNewTerrain)
        {
            unlockTerrain();
            unlockNewTerrain = false;
        }
    }
    private void unlockTerrain()
    {
        this.gameObject.name = "UnlockedTerrain";
        this.gameObject.tag = "UnlockedTerrain";
        myRenderer.material.color = Color.green;
        GameObject.Destroy(buyButton);
        Component.Destroy(this);
    }
}

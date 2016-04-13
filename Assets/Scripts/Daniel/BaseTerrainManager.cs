using UnityEngine;

public class BaseTerrainManager : MonoBehaviour
{
    [SerializeField]
    private bool unlockTerrain;

    public bool UnlockTerrain
    {
        get { return unlockTerrain; }
        set { unlockTerrain = value; }
    }

    private Renderer myRenderer;
    private GameObject buyButton;

    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
        buyButton = transform.FindChild("BuyButton").gameObject;
    }

    private void Update()
    {
        if (unlockTerrain)
            unlock();
    }

    private void unlock()
    {
        this.gameObject.name = "UnlockedTerrain";
        this.gameObject.tag = "UnlockedTerrain";
        myRenderer.material.color = Color.green;
        GameObject.Destroy(buyButton);
        Component.Destroy(this);
    }
}
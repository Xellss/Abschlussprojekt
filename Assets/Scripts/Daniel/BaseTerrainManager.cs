/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;

public class BaseTerrainManager : MonoBehaviour
{
    private GameObject buyButton;
    private Component[] myComponents;
    private Renderer renderer;
    private GameObject towerSlot;
    [SerializeField]
    private bool unlockTerrain;

    public bool UnlockTerrain
    {
        get { return unlockTerrain; }
        set { unlockTerrain = value; }
    }

    private void Awake()
    {
        buyButton = transform.FindChild("BuyButton").gameObject;
        myComponents = transform.GetComponents(typeof(Component));
        renderer = gameObject.GetComponent<Renderer>();
    }

    private void clearComponents()
    {
        foreach (var component in myComponents)
        {
            if ((component.GetType() != typeof(Transform)) && (component.GetType() != typeof(BoxCollider)))
                Component.Destroy(component);
        }
    }

    private void spawnSlots()
    {
        //float pointZero = 4.5f;
        //int towerCount = 1;

        //for (float x = transform.position.x; x < transform.localScale.x + transform.position.x; x++)
        //{
        //    for (float z = transform.position.z; z < transform.localScale.z + transform.position.z; z++)
        //    {
        //        GameObject newTowerslot = (GameObject)Instantiate(towerSlot, new Vector3(x - pointZero, transform.position.y, z - pointZero), Quaternion.identity);
        //        newTowerslot.transform.SetParent(transform);
        //        newTowerslot.name = "TowerSlot_" + towerCount;
        //        towerCount++;
        //    }
        //}
    }

    private void unlock()
    {
        //towerSlot = (GameObject)Resources.Load("Prefabs/TowerSlot");
        //spawnSlots();
        gameObject.name = "UnlockedTerrain";
        gameObject.tag = "UnlockedTerrain";
        //clearComponents();
        Component.Destroy(this);
        renderer.material.color = Color.green;
        GameObject.Destroy(buyButton);
    }

    private void Update()
    {
        if (unlockTerrain)
            unlock();
    }
}

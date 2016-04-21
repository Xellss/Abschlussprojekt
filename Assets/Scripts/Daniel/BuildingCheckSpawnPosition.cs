using UnityEngine;
using System.Collections;

public class BuildingCheckSpawnPosition : MonoBehaviour
{
    Renderer renderer;
    Color myColor;

    private bool canBuild = true;

    public bool CanBuild
    {
        get { return canBuild; }
        set { canBuild = value; }
    }

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        myColor = renderer.material.color;
    }
    public void OnTriggerEnter(Collider other)
    {
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 100f);
        renderer.material.color = Color.red;
        canBuild = false;
    }

    public void OnTriggerExit(Collider other)
    {
        renderer.material.color = myColor;
        canBuild = true;
    }
}

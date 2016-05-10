/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;

public class BuildingCheckSpawnPosition : MonoBehaviour
{
    private bool canBuild = true;
    private Color myColor;
    private Renderer renderer;

    public bool CanBuild
    {
        get { return canBuild; }
        set { canBuild = value; }
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

    public void OnTriggerStay(Collider other)
    {
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 100f);
        renderer.material.color = Color.red;
        canBuild = false;
    }

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        myColor = renderer.material.color;
    }
}

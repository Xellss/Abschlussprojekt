/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////

using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float currentHealth;
    private RectTransform hpBackgroundImage;
    private GameObject hpCanvas;
    private RectTransform canvasRect;
    private RectTransform hpImage;

    private void Awake()
    {
        hpCanvas = transform.FindChild("HP").gameObject;
        canvasRect = hpCanvas.GetComponent<RectTransform>();
        hpBackgroundImage = hpCanvas.transform.FindChild("HPBackgroundImage").GetComponent<RectTransform>();
        hpImage = hpCanvas.transform.FindChild("HPImage").GetComponent<RectTransform>();
    }

    private void Start()
    {
        setMaxSize(canvasRect);
        setMaxSize(hpImage);
        setMaxSize(hpBackgroundImage);

    }

    private void setMaxSize(RectTransform rectangle)
    {
        rectangle.sizeDelta = new Vector2(maxHealth / 100, rectangle.rect.height);
    }
}

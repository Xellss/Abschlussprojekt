using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BillboardingCanvas : MonoBehaviour {

    Transform cameraTransform;
    ShopButtonBehaviour buttonBehaviour;
    Button okButton;
    Button cancelButton;

    RectTransform myRect;

    void Awake()
    {
        myRect = GetComponent<RectTransform>();
        buttonBehaviour = GameObject.Find("Canvas").GetComponent<ShopButtonBehaviour>();
        okButton = transform.FindChild("OK").GetComponent<Button>();
        cancelButton = transform.FindChild("Cancel").GetComponent<Button>();

    }

    void Start()
    {
        okButton.onClick.AddListener(delegate () { buttonBehaviour.OnClickBuild(); });
        cancelButton.onClick.AddListener(delegate () { buttonBehaviour.OnCancelBuildClick(); });
        cameraTransform = GameObject.Find("Main Camera").transform;
    }

    void FixedUpdate()
    {
        //myRect.LookAt(cameraTransform);
        //myRect.rotation = Quaternion.LookRotation((transform.position),-cameraTransform.position);

    }


}

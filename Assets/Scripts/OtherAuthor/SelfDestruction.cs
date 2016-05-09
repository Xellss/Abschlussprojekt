using UnityEngine;
using System.Collections;

public class SelfDestruction : MonoBehaviour
{
    private enum DestroyModes { Destroy, JustDeactivate }

    [SerializeField]
    private float Delay = 10;
    [SerializeField]
    private DestroyModes DestroyMode = DestroyModes.JustDeactivate;

    void Start()
    {
        Invoke("SelfDestruct", Delay);
    }
    private void SelfDestruct()
    {
        switch (DestroyMode)
        {
            case DestroyModes.Destroy:
                Destroy(gameObject);
                break;
            case DestroyModes.JustDeactivate:
                gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}

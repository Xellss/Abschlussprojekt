using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OutpostButtonBehavior : MonoBehaviour {
    [SerializeField]
    private GameObject terrainContainer;

    public void OnClickOutpostMission()
    {
        new GameObject("", typeof(SwitchToOutpostScene));
    }
}

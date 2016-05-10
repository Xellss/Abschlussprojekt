/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using UnityEngine;

public class OutpostButtonBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject terrainContainer;

    public void OnClickOutpostMission()
    {
        new GameObject("", typeof(SwitchToOutpostScene));
    }
}

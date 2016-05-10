using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OutpostButtonBehavior : MonoBehaviour {
    [SerializeField]
    private GameObject terrainContainer;

    public void OnClickOutpostMission()
    {
        StartCoroutine(loadOutpostMission());

    }

    private IEnumerator loadOutpostMission()
    {
        yield return SceneManager.LoadSceneAsync("Prototyp", LoadSceneMode.Additive);
        terrainContainer.SetActive(false);
        this.gameObject.SetActive(false);

        yield return null;
    }

}

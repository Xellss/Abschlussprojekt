using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

[Serializable]
public class loadworld : MonoBehaviour
{
    [SerializeField]
    private float imageShowTime;

    [SerializeField]
    GameObject worldMapDetailsPrefab;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private IEnumerator imageTime()
    {
        yield return new WaitForSeconds(imageShowTime);
        StartCoroutine(load("WorldMap"));
    }

    void Start()
    {
        StartCoroutine(imageTime());
    }

    //public void OnClickStart()
    //{
    //    StartCoroutine(load("WorldMap"));
    //}

    private IEnumerator load(string levelName)
    {
        yield return SceneManager.LoadSceneAsync(levelName);
        Scene level = SceneManager.GetSceneByName(levelName);
        //loadingCanvis.SetActive(false);
        SceneManager.SetActiveScene(level);
        GameObject worldMapDetails = (GameObject)Instantiate(worldMapDetailsPrefab, Vector3.zero, Quaternion.identity);
        worldMapDetails.name = "WorldMapDetails";
        GameObject.Destroy(this.gameObject);
    }
}

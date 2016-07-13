using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadworld : MonoBehaviour {

    public void OnClickStart()
    {
        SceneManager.LoadScene("WorldMap");
    }
}

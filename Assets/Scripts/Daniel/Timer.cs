/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private bool runTimer = false;
    [SerializeField]
    private WaveSpawn spawner;
    [SerializeField]
    private Animator timerAnimator;
    [SerializeField]
    private GameObject timerPanel;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private float timerTime;
    [SerializeField]
    private GameObject buildMenu;

    [SerializeField]
    private GameObject nextWaveButton;

    [SerializeField]
    GameObject newBuildingContainer;

    public float TimerTime
    {
        get { return timerTime; }
        set { timerTime = value; }
    }

    private void Start()
    {
        runTimer = true;
        StartCoroutine(waitASecond());
        timerText.text = ((int)timerTime).ToString();
    }

    private void Update()
    {
        if (timerTime <= 0)
        {
            timerTime = 0;
        }
        else
            timerTime -= Time.deltaTime;
    }

    private IEnumerator waitASecond()
    {
        if (runTimer)
        {
            runTimer = false;
            spawner.CreateSpawnpoints();
        }
        if (timerTime <= 0)
        {
            runTimer = false;
            timerText.text = ((int)timerTime).ToString();
            StopAllCoroutines();
            timerPanel.SetActive(false);
            nextWaveButton.SetActive(true);

            if (newBuildingContainer.transform.childCount>0)
            {
                for (int i = 0; i < newBuildingContainer.transform.childCount; i++)
                {
                    GameObject.Destroy(newBuildingContainer.transform.GetChild(i).gameObject);
                }
            }
            buildMenu.SetActive(false);
            spawner.SpawnEnemy();
        }
        if (TimerTime <= 6)
        {
            timerAnimator.SetTrigger("StartAnimation");
        }
        yield return new WaitForSeconds(1);
        timerText.text = ((int)timerTime + 1).ToString();
        StartCoroutine(waitASecond());
    }
}

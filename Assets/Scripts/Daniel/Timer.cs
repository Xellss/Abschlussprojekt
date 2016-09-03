﻿/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///     Author: Daniel Lause & Julian Hopp    ///
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

    [SerializeField]
    Tutorial tutorial;

    public float TimerTime
    {
        get { return timerTime; }
        set { timerTime = value; }
    }

    public void OnClick_timer()
    {
        timerTime = 0;

        runTimer = false;
        timerText.text = ((int)timerTime).ToString();
        StopAllCoroutines();
        timerPanel.SetActive(false);
        nextWaveButton.SetActive(true);
        if (tutorial != null)
        {
            tutorial.TimerTuTClear = true;
        }

        if (newBuildingContainer.transform.childCount > 0)
        {
            for (int i = 0; i < newBuildingContainer.transform.childCount; i++)
            {
                GameObject.Destroy(newBuildingContainer.transform.GetChild(i).gameObject);
            }
        }
        buildMenu.SetActive(false);
        spawner.BuildPhase = false;
        spawner.SpawnEnemy();
    }

    private void Start()
    {
        if (tutorial == null)
        {
            StartTimer();
        }
        else
        {
            timerText.text = ((int)timerTime).ToString();
        }
    }
    bool startTimer = false;

    public void StartTimer()
    {
        startTimer = true;
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
        else if (startTimer)
        {
            timerTime -= Time.deltaTime;
        }
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
            if (tutorial != null)
            {
                tutorial.TimerTuTClear = true;
            }

            if (newBuildingContainer.transform.childCount > 0)
            {
                for (int i = 0; i < newBuildingContainer.transform.childCount; i++)
                {
                    GameObject.Destroy(newBuildingContainer.transform.GetChild(i).gameObject);
                }
            }
            buildMenu.SetActive(false);
            spawner.BuildPhase = false;
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

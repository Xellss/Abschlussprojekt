using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private WaveSpawn spawner;
    [SerializeField]
    private float timerTime;

    [SerializeField]
    Animator timerAnimator;
    [SerializeField]
    GameObject timerPanel;

    public float TimerTime
    {
        get { return timerTime; }
        set { timerTime = value; }
    }

    [SerializeField]
    private Text timerText;

    private bool runTimer = false;
    void Start()
    {
        runTimer = true;
        StartCoroutine(waitASecond());
        timerText.text = ((int)timerTime).ToString();

    }
    void Update()
    {

        if (timerTime <= 0)
        {
            timerTime = 0;
        }
        else
        timerTime -= Time.deltaTime;

    }
    IEnumerator waitASecond()
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
            spawner.SpawnEnemy();
        }
        if (runTimer &&TimerTime <= 5)
        {
            timerAnimator.SetTrigger("StartAnimation");
        }
        yield return new WaitForSeconds(1);
        timerText.text = ((int)timerTime+1).ToString();
        StartCoroutine(waitASecond());

    }
}

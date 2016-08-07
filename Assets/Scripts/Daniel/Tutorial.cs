using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{

    [SerializeField]
    Animator buildTut;
    [SerializeField]
    Animator timerTut;
    [SerializeField]
    Animator rotateTut;
    [SerializeField]
    Timer timer;

    [SerializeField]
    GameObject BaseRing1;
    [SerializeField]
    GameObject BaseRing2;
    [SerializeField]
    GameObject BaseRing3;


    [SerializeField]
    private bool buildTuTClear;

    public bool BuildTutClear
    {
        get { return buildTuTClear; }
        set { buildTuTClear = value; }
    }
    [SerializeField]
    private bool timerTuTClear;

    public bool TimerTuTClear
    {
        get { return timerTuTClear; }
        set { timerTuTClear = value; }
    }
    [SerializeField]
    private bool rotateTuTClear;

    public bool RotateTutClear
    {
        get { return rotateTuTClear; }
        set { rotateTuTClear = value; }
    }


    [SerializeField]
    private bool buildInProgress;

    public bool BuildInProgress
    {
        get { return buildInProgress; }
        set { buildInProgress = value; }
    }

    [SerializeField]
    private bool timerAnimationStart;

    public bool TimerAnimationStart
    {
        get { return timerAnimationStart; }
        set { timerAnimationStart = value; }
    }



    void Start()
    {
        UpdateTutorial();
    }

    public void UpdateTutorial()
    {
        if (!buildTuTClear)
        {
            if (!buildInProgress)
            {
                buildTut.SetTrigger("StartTut");
                StartCoroutine(updateTimer(4));
            }
            else
            {
                StartCoroutine(updateTimer(1));
            }
        }
        else if (!timerTuTClear)
        {
            if (!timerAnimationStart)
            {
                timerAnimationStart = true;
                timer.StartTimer();
            }

            timerTut.SetTrigger("StartTut");
                StartCoroutine(updateTimer(1));
        }
        else if (!rotateTuTClear)
        {
            timerTut.gameObject.SetActive(false);
            rotateTut.SetTrigger("StartTut");
            BaseRing1.AddComponent<BaseRotation>();
            BaseRing2.AddComponent<BaseRotation>();
            BaseRing3.AddComponent<BaseRotation>();
            StartCoroutine(updateTimer(3));

        }

    }


    IEnumerator updateTimer(float time)
    {
        yield return new WaitForSeconds(time);
        UpdateTutorial();
    }
}

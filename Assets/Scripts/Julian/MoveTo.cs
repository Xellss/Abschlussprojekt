/////////////////////////////////////////////////
/////////////////////////////////////////////////

using System.Collections;
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Julian Hopp             ///
///                                           ///
///                                           ///
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform goal;
    private GameObject[] mainBaseBuildings;

    public bool MainBaseLevel;
    private bool setLevel = false;
    public bool SearchNewBuilding = true;
    float distance = 99999999;
    GameObject loseScreen;
    GameObject currentAttackBuilding;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(resetPath());
        loseScreen = GameObject.Find("Lose_Image");
    }

    IEnumerator resetPath()
    {
        yield return new WaitForEndOfFrame();
        SearchNewBuilding = true;
        StartCoroutine(resetPath());

    }
    private void LateUpdate()
    {
        if (!MainBaseLevel)
        {
            if (!setLevel)
            {
                if (GameObject.Find("Goal") != null)
                {

                    goal = GameObject.Find("Goal").transform;
                    agent.SetDestination(goal.position);
                    setLevel = true;
                }
            }
            if (agent.pathStatus == NavMeshPathStatus.PathInvalid)
            {

            }
        }
        else if (MainBaseLevel)
        {

            if (SearchNewBuilding)
            {

                if (GameObject.FindGameObjectsWithTag("Building")!=null)
                {

                mainBaseBuildings = GameObject.FindGameObjectsWithTag("Building");
                distance = 9999999f;
                foreach (var building in mainBaseBuildings)
                {
                    if (distance > Vector3.Distance(transform.position, building.transform.position))
                    {
                        distance = Vector3.Distance(transform.position, building.transform.position);
                        currentAttackBuilding = building;
                    }
                }
                agent.SetDestination(currentAttackBuilding.transform.position);
                SearchNewBuilding = false;
                }
                else
                {
                    //LOSE SCREEN !!! 
                }
            }
        }

    }
}

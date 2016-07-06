using UnityEngine;
using System.Collections;
using DG.Tweening;


public class Paths : MonoBehaviour
{
	public PathType pathType = PathType.CatmullRom;
    public Transform[] waypointObjects;
    public Vector3[] waypoints;


    public int duration;
    private Transform target;

    void Start()
	{

        target = this.transform;
        waypoints = new Vector3[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].position;
        }
		Tween t = target.DOPath(waypoints, duration, pathType)
			.SetOptions(true)
			.SetLookAt(0.001f);

		t.SetEase(Ease.Linear).SetLoops(-1);
	}
}
﻿using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Linq;

public class EnemyKi : MonoBehaviour
{

    Transform waypointArray;

    [SerializeField]
    GameObject laserSpawnPosition;

    [SerializeField]
    PoolPrefab laserBullet;

    [SerializeField]
    private int damage;

    [SerializeField]
    private float laserSpeed;

    [SerializeField]
    private float shotDelay;

    private GameObject newLaser;

    [SerializeField]
    private bool canShot;

    [SerializeField]
    private bool shotNow;

    [SerializeField]
    private PathType pathType = PathType.CatmullRom;
    //[SerializeField]
    private Transform[] waypointObjects;

    private Vector3[] waypoints;

    [SerializeField, Tooltip("lower = faster")]
    int flySpeed = 0;

    RaycastHit hit;

    void Update()
    {
        if (shotNow)
        {
            shot();
            shotNow = false;
        }
    }

    void Awake()
    {
        waypointArray = GameObject.Find("EnemyWaypoints").transform;
        waypointObjects = waypointArray.Cast<Transform>().ToArray();
    }
    void Start()
    {
        setPath();
        laserSpeed = laserSpeed * 1000;
    }
    void shot()
    {
        StartCoroutine(shotWithDelay());
    }

    void setPath()
    {
        waypoints = new Vector3[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].position;
        }
        Tween t = transform.DOPath(waypoints, flySpeed, pathType)
            .SetOptions(true)
            .SetLookAt(0.001f);

        t.SetEase(Ease.Linear).SetLoops(-1);
    }

    IEnumerator shotWithDelay()
    {
        if (canShot)
        {

            Ray ray = new Ray(laserSpawnPosition.transform.position, transform.forward);
            Physics.Raycast(ray, out hit);
            if (hit.collider != null && hit.collider.gameObject.tag == "Building")
            {

                newLaser = ObjectPool.Instance.GetPooledObject(laserBullet);
                newLaser.transform.position = laserSpawnPosition.transform.position;
                Rigidbody laserBody = newLaser.GetComponent<Rigidbody>();
                laserBody.transform.LookAt(transform.forward);
                laserBody.AddForce(transform.forward * laserSpeed * Time.deltaTime, ForceMode.Impulse);
                yield return new WaitForSeconds(shotDelay);
            }
            else
                yield return new WaitForSeconds(0);
            StartCoroutine(shotWithDelay());
        }
    }
}

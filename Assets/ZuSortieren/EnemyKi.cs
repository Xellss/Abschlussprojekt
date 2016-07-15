/////////////////////////////////////////////////
///                                           ///
///      Source Code - Abschlussprojekt       ///
///                                           ///
///           Author: Daniel Lause            ///
///                                           ///
///                                           ///
/////////////////////////////////////////////////
using DG.Tweening;
using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemyKi : MonoBehaviour
{
    [SerializeField]
    private bool canShot;
    [SerializeField]
    private int damage;
    [SerializeField, Tooltip("lower = faster")]
    private int flySpeed = 0;
    private RaycastHit hit;
    [SerializeField]
    private PoolPrefab laserBullet;
    [SerializeField]
    private GameObject laserSpawnPosition;
    [SerializeField]
    private float laserSpeed;
    private GameObject newLaser;
    [SerializeField]
    private PathType pathType = PathType.CatmullRom;
    [SerializeField]
    private float shotDelay;
    [SerializeField]
    private bool shotNow;
    private Transform waypointArray;
    private Transform[] waypointObjects;

    private Vector3[] waypoints;

    private void Awake()
    {
        waypointArray = GameObject.Find("EnemyWaypoints").transform;
        waypointObjects = waypointArray.Cast<Transform>().ToArray();
    }

    private void setPath()
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

    private void shot()
    {
        StartCoroutine(shotWithDelay());
    }

    private IEnumerator shotWithDelay()
    {
        if (canShot)
        {
            Ray ray = new Ray(laserSpawnPosition.transform.position, transform.forward);
            Physics.Raycast(ray, out hit);
            if (hit.collider != null && hit.collider.gameObject.tag == "Building")
            {
                newLaser = ObjectPool.Instance.GetPooledObject(laserBullet);
                newLaser.GetComponent<LaserInfos>().Damage = damage;
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

    private void Start()
    {
        setPath();
        laserSpeed = laserSpeed * 1000;
    }

    private void Update()
    {
        if (shotNow)
        {
            shot();
            shotNow = false;
        }
    }
}
